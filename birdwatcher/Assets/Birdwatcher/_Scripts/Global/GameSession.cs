using System.Collections.Generic;
using Birdwatcher.Input;
using Birdwatcher.Model.Birds;
using Birdwatcher.UI;

namespace Birdwatcher.Global {

    public class GameSession {

        public List<IObservable> IdentifiedSpecies { get; set; } = new List<IObservable> ();
        public List<IPausable> pausables { get; } = new List<IPausable> ();
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
                if (!IsPaused) OnPause ();
                else OnUnpause ();
            };
        }

        public void OnPause () {

            for (int i = 0; i < pausables.Count; i++)
                pausables[i].OnPause ();

            SingletonManager.GetSingleton<UI.UIManager> ().LoadUI (new UI.PauseUIData (), (controller) => {

                pauseController = (PauseController) controller;
            });
        }

        public void OnUnpause () {

            pauseController.UnloadPauseMenus ();

            for (int i = 0; i < pausables.Count; i++)
                pausables[i].OnUnpause ();
        }
    }
}