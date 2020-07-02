using Birdwatcher.Input;
using Birdwatcher.Cameras.Model;
using DG.Tweening;
using UnityEngine;

namespace Birdwatcher.Cameras.Controller {

    public class BinocularsController : CameraController {

        private Binoculars binoculars;

        private bool isUsing;
        private float rangeInterval = 1;
        private Camera mainCamera;
        private Vector3 startPosition;

        private const float SENSIBILITY = 0.05f;
        private const RegistrableKeys BINOCULARS_KEY = RegistrableKeys.KEY_A;

        void OnDestroy () => DestroyBinoculars ();

        public override void Initialize () {

            base.Initialize ();

            binoculars = new Binoculars (40, 20);

            mainCamera = Camera.main;
            virtualCamera.m_Lens.FieldOfView = binoculars.MinRange;
            virtualCamera.enabled = false;

            startPosition = transform.localPosition;

            var binocularsKey = InputManager.Instance.RegisterKey (BINOCULARS_KEY, KeyCode.Mouse1);
            binocularsKey.OnKeyDown += PutBinoculars;
            binocularsKey.OnKeyUp += RemoveBinoculars;
        }

        void Update () {

            if (isUsing)
                Zoom (InputManager.Instance.GetMouseAxis (MouseAxis.SCROLL_WHEEL));
        }

        public void PutBinoculars () {

            virtualCamera.enabled = true;
            isUsing = true;
        }

        public void RemoveBinoculars () {

            isUsing = false;
            virtualCamera.enabled = false;
        }

        public void Zoom (float zoomMultiplier) {

            if (zoomMultiplier == 0) return;
            rangeInterval += (binoculars.MinRange - binoculars.MaxRange) * SENSIBILITY * zoomMultiplier * -1;
            rangeInterval = Mathf.Clamp01 (rangeInterval);
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp (binoculars.MaxRange, binoculars.MinRange, rangeInterval);
        }

        private void DestroyBinoculars () {

            InputManager.Instance.UnregisterKey (BINOCULARS_KEY);
        }
    }
}