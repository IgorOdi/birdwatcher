using Birdwatcher.Model.Player;
using Birdwatcher.Input;
using Birdwatcher.Input.Enum;
using UnityEngine;

namespace Birdwatcher.Controller.Player {

    [RequireComponent (typeof (CharacterController))]
    public class PlayerController : MonoBehaviour {

        public PlayerData player;
        private CharacterController controller;

        public void Awake () {

            player = new PlayerData (9);
            controller = GetComponent<CharacterController> ();
        }

        public void Update () {

            var h = FindObjectOfType<InputManager> ().GetAxis (Axis.HORIZONTAL);
            var v = FindObjectOfType<InputManager> ().GetAxis (Axis.VERTICAL);

            controller.SimpleMove (new Vector3 (h, 0, v) * player.GetSpeed (false));
        }
    }
}