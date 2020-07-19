using Birdwatcher.Global;
using Birdwatcher.Input;
using Cinemachine;
using UnityEngine;

namespace Birdwatcher.Controller.Cameras {

    public class CameraController : MonoBehaviour, IPausable {

        protected InputManager inputManager;
        protected CinemachineVirtualCamera virtualCamera;

        private float mouseVerticalLook;
        private float mouseHorizontalLook;

        private float sensibility = BASE_SENSIBILITY;
        private const float BASE_SENSIBILITY = 3;

        private void Awake () => Initialize ();

        public virtual void Initialize () {

            inputManager = SingletonManager.GetSingleton<InputManager> ();
            virtualCamera = GetComponent<CinemachineVirtualCamera> ();

            SingletonManager.GetSingleton<GameManager> ().ToggleCursor (locked: true);
            this.RegisterPausable ();

            sensibility = BASE_SENSIBILITY;
        }

        public void SetLookPoint (Transform lookPoint) {

            virtualCamera.m_Follow = lookPoint;
            virtualCamera.m_LookAt = lookPoint;
        }

        private void LateUpdate () {

            mouseVerticalLook += inputManager.GetMouseAxis (MouseAxis.Y) * sensibility;
            mouseVerticalLook = Mathf.Clamp (mouseVerticalLook, -80, 40);

            mouseHorizontalLook += inputManager.GetMouseAxis (MouseAxis.X) * sensibility;
            transform.eulerAngles = Vector3.up * mouseHorizontalLook + Vector3.left * mouseVerticalLook;
        }

        public void OnPause () {
            sensibility = 0;
        }

        public void OnUnpause () {
            sensibility = BASE_SENSIBILITY;
        }
    }
}