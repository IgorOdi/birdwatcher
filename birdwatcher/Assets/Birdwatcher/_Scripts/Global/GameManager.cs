using Birdwatcher.Utils;
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
                Log.V ("Locked Mouse");
            } else {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Log.V ("Unlocked Mouse");
            }
        }
    }
}