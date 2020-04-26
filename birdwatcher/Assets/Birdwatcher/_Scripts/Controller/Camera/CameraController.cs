using Birdwatcher.Input;
using Birdwatcher.Input.Enum;
using UnityEngine;

namespace Birdwatcher.Controller.Cameras {

    public class CameraController : MonoBehaviour {

        private Camera cam;
        [SerializeField]
        private Transform lookPoint;

        private float mouseVerticalLook;
        private float mouseHorizontalLook;

        private const float BASE_SENSIBILITY = 3;
        private const float BASE_OFFSET = -4.5f;

        void Awake () => Initialize ();

        public void Initialize () {

            //this.lookPoint = lookPoint;
            cam = GetComponentInChildren<Camera> ();
            SetOffset (Vector3.forward * BASE_OFFSET);

            //Cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void LateUpdate () {

            mouseVerticalLook += InputManager.Instance.GetMouseAxis (MouseAxis.Y) * BASE_SENSIBILITY;
            mouseVerticalLook = Mathf.Clamp (mouseVerticalLook, -80, 40);

            mouseHorizontalLook += InputManager.Instance.GetMouseAxis (MouseAxis.X) * BASE_SENSIBILITY;
            transform.eulerAngles = Vector3.up * mouseHorizontalLook + Vector3.left * mouseVerticalLook;

            transform.position = Vector3.Lerp (transform.position, lookPoint.position, 0.05f);
        }

        private void SetOffset (Vector3 offset) {

            cam.transform.localPosition = offset;
        }
    }
}