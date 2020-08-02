using System.Collections.Generic;
using Birdwatcher.Global.Updating;
using Birdwatcher.Input;
using Birdwatcher.Model.Birds;
using Birdwatcher.UI;

namespace Birdwatcher.Global {

    public class GameSession {

        public List<IObservable> IdentifiedSpecies { get; set; } = new List<IObservable> ();
        public List<IUpdatable> Updatables { get; } = new List<IUpdatable> ();
        public bool IsPaused { get { return pauseController != null; } }

        private PauseController pauseController;

        public GameSession (List<IObservable> identifiedSpecies) {

            this.IdentifiedSpecies = identifiedSpecies;
            InternalConstructor ();
        }

        public GameSession () => InternalConstructor ();

        private void InternalConstructor () {

            InputManager inputManager = SingletonManager.GetSingleton<InputManager> ();

            inputManager.GetKey (BirdKeys.PAUSE).OnKeyDown += () => {
                if (!IsPaused) OnSessionPause ();
                else OnSessionUnpause ();
            };
        }

        public void SessionUpdate () {

            for (int i = 0; i < Updatables.Count; i++)

                if (Updatables[i].UpdatableTypes.Equals (UpdatableTypes.NORMAL))
                    Updatables[i].OnUpdate ();
        }

        public void SessionFixedUpdate () {

            for (int i = 0; i < Updatables.Count; i++)
                if (Updatables[i].UpdatableTypes.Equals (UpdatableTypes.FIXED))
                    Updatables[i].OnFixedUpdate ();
        }

        public void SessionLateUpdate () {

            for (int i = 0; i < Updatables.Count; i++) {
                if (Updatables[i].UpdatableTypes.Equals (UpdatableTypes.LATE))
                    Updatables[i].OnLateUpdate ();
            }
        }

        public void OnSessionPause () {

            SingletonManager.GetSingleton<UI.UIManager> ().LoadUI (new UI.PauseUIData (), (controller) => {

                pauseController = (PauseController) controller;
            });
        }

        public void OnSessionUnpause () {

            pauseController.UnloadPauseMenus ();;
        }
    }
}