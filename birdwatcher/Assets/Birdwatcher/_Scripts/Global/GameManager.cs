using Birdwatcher.Input;
using Birdwatcher.Utils;
using UnityEngine;

namespace Birdwatcher.Global {

    public class GameManager : MonoBehaviour {

        public GameSession CurrentGameSession { get; set; }

        public void Initialize () {

            this.SubscribeAsSingleton ();
            SetGameplayKeys ();
            CurrentGameSession = new GameSession ();
        }

        public void SetGameplayKeys () {

            var inputManager = SingletonManager.GetSingleton<InputManager> ();

            inputManager.ClearKeys ();
            inputManager.RegisterKey (BirdKeys.BINOCULARS, KeyCode.Mouse1);
            inputManager.RegisterKey (BirdKeys.CROUCH, KeyCode.LeftControl);
            inputManager.RegisterKey (BirdKeys.PAUSE, KeyCode.Tab);
        }

        public void SetMenuKeys () {

            var inputManager = SingletonManager.GetSingleton<InputManager> ();
            inputManager.ClearKeys ();
            //TODO: Configure for menus;
        }

        public void ToggleCursor (bool locked) {

            if (locked) {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Log.V ("Locked Cursor");
            } else {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Log.V ("Unlocked Cursor");
            }
        }

        #region UPDATING GAME SESSION

        private void Update () {
            if (CurrentGameSession != null && !CurrentGameSession.IsPaused)
                CurrentGameSession.SessionUpdate ();
        }

        private void FixedUpdate () {
            if (CurrentGameSession != null && CurrentGameSession.IsPaused)
                CurrentGameSession.SessionFixedUpdate ();
        }

        private void LateUpdate () {
            if (CurrentGameSession != null && CurrentGameSession.IsPaused)
                CurrentGameSession.SessionLateUpdate ();
        }

        #endregion
    }
}