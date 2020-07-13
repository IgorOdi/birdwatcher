using UnityEngine;

namespace Birdwatcher.Global {

    public class GameManager : MonoBehaviour {

        public GameSession CurrentGameSession { get; set; }

        public void Initialize () {

            this.SubscribeAsSingleton ();
            CurrentGameSession = new GameSession ();
        }

        public void ToggleCursor (bool locked) {

            if (locked) {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log ("Locked Mouse");
            } else {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Debug.Log ("Unlocked Mouse");
            }
        }
    }
}