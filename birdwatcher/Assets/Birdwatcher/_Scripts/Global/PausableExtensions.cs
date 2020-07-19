namespace Birdwatcher.Global {

    public static class PausableExtensions {

        public static void RegisterPausable (this IPausable pausable) {

            SingletonManager.GetSingleton<GameManager> ().CurrentGameSession.pausables.Add (pausable);
        }
    }
}