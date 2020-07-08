using System.Collections;
using Birdwatcher.Input;
using Birdwatcher.Model.Cameras;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Birdwatcher.Global;

namespace Birdwatcher.Controller.Cameras {

    public class BinocularsController : CameraController {

        private Binoculars binoculars;
        private Volume volume;
        private VolumeProfile volumeProfile;
        private DepthOfField depthOfField;

        private bool isUsing;
        private float rangeInterval = 0;
        private Camera mainCamera;
        private Vector3 startPosition;
        private RaycastHit hit;

        private IObservable identifyingBird;
        private Coroutine identifyingCoroutine;

        private const RegistrableKeys BINOCULARS_KEY = RegistrableKeys.KEY_A;
        private const float SENSIBILITY = 0.025f;

        public override void Initialize () {

            base.Initialize ();

            binoculars = new Binoculars (20, 40);
            volume = GetComponent<Volume> ();
            volume.profile.TryGet<DepthOfField> (out depthOfField);
            volume.enabled = false;

            mainCamera = Camera.main;
            virtualCamera.m_Lens.FieldOfView = binoculars.MinZoom;
            virtualCamera.enabled = false;

            startPosition = transform.localPosition;

            var binocularsKey = inputManager.RegisterKey (BINOCULARS_KEY, KeyCode.Mouse1);
            binocularsKey.OnKeyDown += PutBinoculars;
            binocularsKey.OnKeyUp += RemoveBinoculars;
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
            //if (Physics.Raycast (transform.position, transform.forward, out hit, binoculars.FocusPoint)) {
            if (Physics.SphereCast (transform.position, 2f, transform.forward, out hit, binoculars.FocusPoint)) {

                IObservable observable;
                if (hit.transform.TryGetComponent<IObservable> (out observable)) {

                    if (observable != identifyingBird) {
                        //Debug.Log ($"Encontrou {observable.GetObservationData().Name}");
                        Debug.Log ($"Encontrou {observable.GetHashCode()}");
                        identifyingBird = observable;
                        identifyingCoroutine = StartCoroutine (IdentifyBird ());
                    }
                } else {

                    CancelIdentifying ();
                }
            } else {

                CancelIdentifying ();
            }
        }

        private IEnumerator IdentifyBird () {

            float t = 0;
            while (t < 1f) {

                t += Time.deltaTime;
                Debug.Log ($"Identificando em {System.Math.Round(1 - t, 1)} segundos");
                yield return null;
            }

            Debug.Log ($"Identificou {identifyingBird.GetHashCode()}");
            //Debug.Log ($"Identificou {identifyingBird.GetObservationData().Name}!");
        }

        private void CancelIdentifying () {

            identifyingBird = null;
            if (identifyingCoroutine != null) StopCoroutine (identifyingCoroutine);
        }

        void OnDrawGizmos () {

            if (binoculars == null || !isUsing) return;
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay (transform.position, transform.position + transform.forward * binoculars.FocusPoint);
            Gizmos.DrawWireSphere (transform.position + transform.forward * binoculars.FocusPoint, 2f);
        }
    }
}