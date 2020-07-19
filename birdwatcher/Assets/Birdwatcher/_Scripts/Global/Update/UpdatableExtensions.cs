namespace Birdwatcher.Global.Updating {

    public static class UpdatableExtensions {

        public static void RegisterUpdatable (this IUpdatable updatable, UpdatableTypes updatableTypes) {

            SingletonManager.GetSingleton<GameManager> ().CurrentGameSession.Updatables.Add (updatable);
        }

        public static void UnregisterUpdatable (this IUpdatable updatable) {

            SingletonManager.GetSingleton<GameManager> ().CurrentGameSession.Updatables.Remove (updatable);
        }
    }
}