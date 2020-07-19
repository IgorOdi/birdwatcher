using Birdwatcher.Input;
using Birdwatcher.UI;
using UnityEngine;

namespace Birdwatcher.Global.Bootstrapping {

    public class Bootstrapper : MonoBehaviour {

        [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnStartGame () {

            Instantiate<InputManager> ().Initialize ();
            Instantiate<UIManager> ().Initialize ();
            Instantiate<GameManager> ().Initialize ();
        }

        private static T Instantiate<T> () where T : Component {

            GameObject g = new GameObject (typeof (T).Name);
            var component = g.AddComponent<T> ();
            DontDestroyOnLoad (g);
            return component;
        }
    }
}