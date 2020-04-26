using Birdwatcher.Input;
using Birdwatcher.Input.Enum;
using Birdwatcher.Model.Player;
using UnityEngine;

namespace Birdwatcher.Controller.Player {

    [RequireComponent (typeof (CharacterController))]
    public class PlayerController : MonoBehaviour {

        public PlayerData playerData = new PlayerData ();

        private CharacterController controller;
        private Animator animator;
        private Vector3 velocity;
        private Vector3 moveDirection;

        private int speedParam;
        private int directionParam;
        private const string SPEED_PARAM = "Speed";
        private const string DIRECTION_PARAM = "Direction";

        void Awake () => Initialize ();

        private void Initialize () {

            controller = GetComponent<CharacterController> ();
            animator = GetComponentInChildren<Animator> ();
            speedParam = Animator.StringToHash (SPEED_PARAM);
            directionParam = Animator.StringToHash (DIRECTION_PARAM);
        }

        public void Update () {

            velocity = Vector3.forward * InputManager.Instance.GetAxis (KeyAxis.VERTICAL) +
                Vector3.right * InputManager.Instance.GetAxis (KeyAxis.HORIZONTAL);
            bool speedReduced = velocity.z < 0;
            moveDirection = transform.TransformDirection (velocity.normalized) * playerData.GetSpeed (speedReduced) * Time.deltaTime;

            controller.Move (moveDirection);
            transform.eulerAngles += Vector3.up * InputManager.Instance.GetMouseAxis (MouseAxis.X) * 3;

            animator.SetFloat (speedParam, velocity.magnitude);
            animator.SetFloat (directionParam, velocity.z);
        }
    }
}