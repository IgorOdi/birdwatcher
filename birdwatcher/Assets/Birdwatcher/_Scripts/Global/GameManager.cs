using Birdwatcher.Input;
using Birdwatcher.Utils;
using UnityEngine;

namespace Birdwatcher.Global {

    public class GameManager : MonoBehaviour {

        public GameSession CurrentGameSession { get; set; }

        public void Initialize () {

            this.SubscribeAsSingleton ();
            var inputManager = SingletonManager.GetSingleton<InputManager> ();

            //Fix for out of gameplay
            inputManager.RegisterKey (BirdKeys.BINOCULARS, KeyCode.Mouse1);
            inputManager.RegisterKey (BirdKeys.CROUCH, KeyCode.LeftControl);
            inputManager.RegisterKey (BirdKeys.PAUSE, KeyCode.Tab);

            CurrentGameSession = new GameSession ();
        }

        public void ToggleCursor (bool locked) {

            if (locked) {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Log.V ("Locked Mouse");
            } else {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Log.V ("Unlocked Mouse");
            }
        }
    }
}