using Birdwatcher.Input;
using Birdwatcher.Input.Enum;
using Birdwatcher.Model.Player;
using UnityEngine;

namespace Birdwatcher.Controller.Player {

    [RequireComponent (typeof (CharacterController))]
    public class PlayerController : MonoBehaviour {

        public PlayerData playerData = new PlayerData ();
        private CharacterController controller;

        public void Awake () {

            controller = GetComponent<CharacterController> ();
        }

        public void Update () {

            controller.SimpleMove (GetVelocity ());
        }

        private Vector3 GetVelocity () {

            return (Vector3.forward * InputManager.Instance.GetAxis (KeyAxis.VERTICAL) + Vector3.right *
                InputManager.Instance.GetAxis (KeyAxis.HORIZONTAL)).normalized * playerData.GetSpeed (false);
        }
    }
}