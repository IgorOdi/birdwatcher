using Birdwatcher.Input;
using Cinemachine;
using UnityEngine;

namespace Birdwatcher.Controller.Cameras {

    public class CameraController : MonoBehaviour {

        protected CinemachineVirtualCamera virtualCamera;

        private float mouseVerticalLook;
        private float mouseHorizontalLook;

        private const float BASE_SENSIBILITY = 3;

        private void Start () => Initialize ();

        public virtual void Initialize () {

            virtualCamera = GetComponent<CinemachineVirtualCamera> ();

            //Cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void SetLookPoint (Transform lookPoint) {

            virtualCamera.m_Follow = lookPoint;
            virtualCamera.m_LookAt = lookPoint;
        }

        private void LateUpdate () {

            mouseVerticalLook += InputManager.Instance.GetMouseAxis (MouseAxis.Y) * BASE_SENSIBILITY;
            mouseVerticalLook = Mathf.Clamp (mouseVerticalLook, -80, 40);

            mouseHorizontalLook += InputManager.Instance.GetMouseAxis (MouseAxis.X) * BASE_SENSIBILITY;
            transform.eulerAngles = Vector3.up * mouseHorizontalLook + Vector3.left * mouseVerticalLook;
        }
    }
}