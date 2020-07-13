using System.Collections;
using System.Linq;
using Birdwatcher.Global;
using Birdwatcher.Input;
using Birdwatcher.Model.Birds;
using Birdwatcher.Model.Cameras;
using Birdwatcher.UI;
using Birdwatcher.Utils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Birdwatcher.Controller.Cameras {

    public class BinocularsController : CameraController {

        private Binoculars binoculars;
        private Volume volume;
        private VolumeProfile volumeProfile;
        private DepthOfField depthOfField;

        private bool isUsing;
        private float rangeInterval = 0;
        private RaycastHit hit;

        private IObservable identifyingBird;
        private Coroutine identifyingCoroutine;
        private BinocularsUIController uiController;
        private BinocularsUIData binocularsUIData = new BinocularsUIData ();
        private GameSession gameSession;

        private const BirdKeys BINOCULARS_KEY = BirdKeys.A;
        private const float SENSIBILITY = 0.025f;
        private const float IDENTIFY_TIME = 2f;

        public override void Initialize () {

            base.Initialize ();

            binoculars = new Binoculars (20, 40);
            volume = GetComponent<Volume> ();
            volume.profile.TryGet<DepthOfField> (out depthOfField);
            volume.enabled = false;

            virtualCamera.m_Lens.FieldOfView = binoculars.MinZoom;
            virtualCamera.enabled = false;

            var binocularsKey = inputManager.RegisterKey (BINOCULARS_KEY, KeyCode.Mouse1);
            binocularsKey.OnKeyDown += PutBinoculars;
            binocularsKey.OnKeyUp += RemoveBinoculars;

            gameSession = SingletonManager.GetSingleton<GameManager> ().CurrentGameSession;
            SingletonManager.GetSingleton<UIManager> ().LoadUI (binocularsUIData, (controller) => {

                uiController = (BinocularsUIController) controller;
            });
        }

        private void PutBinoculars () {

            virtualCamera.enabled = true;
            volume.enabled = true;
            isUsing = true;
        }

        private void RemoveBinoculars () {

            volume.enabled = false;
            virtualCamera.enabled = false;
            isUsing = false;
            CancelIdentifying ();
        }

        private void Update () {

            if (isUsing) {
                Zoom (inputManager.GetMouseAxis (MouseAxis.SCROLL_WHEEL));
                WatchForBirds ();
            }
        }

        private void Zoom (float zoomMultiplier) {

            rangeInterval += (binoculars.MinZoom - binoculars.MaxZoom) * SENSIBILITY * zoomMultiplier * -1;
            rangeInterval = Mathf.Clamp01 (rangeInterval);

            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp (binoculars.MinZoom, binoculars.MaxZoom, 1 - rangeInterval);
            binoculars.FocusPoint = Mathf.Lerp (binoculars.MinZoom, binoculars.MaxZoom, rangeInterval);
            depthOfField.gaussianStart.value = binoculars.FocusPoint + 2;
            depthOfField.gaussianEnd.value = binoculars.FocusPoint + 3;
        }

        private void WatchForBirds () {

            //Store observed birds
            IObservable observable;
            if (Physics.Raycast (transform.position, transform.forward, out hit, binoculars.FocusPoint) &&
                hit.transform.TryGetComponent<IObservable> (out observable)) {

                if (observable != identifyingBird) {

                    identifyingBird = observable;
                    var birdData = identifyingBird.GetObservationData ();
                    if (gameSession.IdentifiedSpecies.Any (bird => bird.GetObservationData ().Equals (birdData))) {

                        string identifyText = $"Espécie {birdData.Name} já catalogada";
                        uiController.SetMainDisplay (identifyText);
                        Debug.Log (identifyText);
                    } else {

                        Debug.Log ($"Encontrou {birdData.Name}");
                        identifyingCoroutine = StartCoroutine (IdentifyBird ());
                    }
                }
            } else {

                CancelIdentifying ();
            }
        }

        private IEnumerator IdentifyBird () {

            float t = 0;
            uiController.SetMainDisplay ("Identificando nova espécie...");
            while (t < IDENTIFY_TIME) {

                uiController.SetProgressBar (t / IDENTIFY_TIME);
                Debug.Log ($"Identificando nova espécie em {System.Math.Round(IDENTIFY_TIME - t, 1)} segundos");
                t += Time.deltaTime;
                yield return null;
            }

            gameSession.IdentifiedSpecies.Add (identifyingBird);
            string identifyText = $"Identificou {identifyingBird.GetObservationData().Name}!";
            uiController.SetMainDisplay (identifyText, resetText : true, resetTime : 2f);
            this.RunDelayed (2f, () => uiController.ToggleProgressBar (active: false));
            Debug.Log (identifyText);
        }

        private void CancelIdentifying () {

            identifyingBird = null;
            uiController.SetMainDisplay ("");
            uiController.ToggleProgressBar (active: false);
            if (identifyingCoroutine != null) StopCoroutine (identifyingCoroutine);
        }

        void OnDrawGizmos () {

            if (binoculars == null || !isUsing) return;
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay (transform.position, transform.forward * binoculars.FocusPoint);
            //Gizmos.DrawWireSphere (transform.position + transform.forward * binoculars.FocusPoint, 2f);
        }
    }
}