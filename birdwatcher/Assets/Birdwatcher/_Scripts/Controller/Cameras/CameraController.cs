using Birdwatcher.Global;
using Birdwatcher.Input;
using Cinemachine;
using UnityEngine;

namespace Birdwatcher.Controller.Cameras {

    public class CameraController : MonoBehaviour {

        protected InputManager inputManager;
        protected CinemachineVirtualCamera virtualCamera;

        private float mouseVerticalLook;
        private float mouseHorizontalLook;

        private const float BASE_SENSIBILITY = 3;

        private void Awake () => Initialize ();

        public virtual void Initialize () {

            inputManager = SingletonManager.GetSingleton<InputManager> ();
            virtualCamera = GetComponent<CinemachineVirtualCamera> ();

            SingletonManager.GetSingleton<GameManager> ().ToggleCursor (locked: true);
        }

        public void SetLookPoint (Transform lookPoint) {

            virtualCamera.m_Follow = lookPoint;
            virtualCamera.m_LookAt = lookPoint;
        }

        private void LateUpdate () {

            mouseVerticalLook += inputManager.GetMouseAxis (MouseAxis.Y) * BASE_SENSIBILITY;
            mouseVerticalLook = Mathf.Clamp (mouseVerticalLook, -80, 40);

            mouseHorizontalLook += inputManager.GetMouseAxis (MouseAxis.X) * BASE_SENSIBILITY;
            transform.eulerAngles = Vector3.up * mouseHorizontalLook + Vector3.left * mouseVerticalLook;
        }
    }
}