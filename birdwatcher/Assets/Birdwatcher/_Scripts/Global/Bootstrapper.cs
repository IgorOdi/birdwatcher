using Birdwatcher.Input;
using Birdwatcher.UI;
using UnityEngine;

namespace Birdwatcher.Global {

    public class Bootstrapper : MonoBehaviour {

        [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnStartGame () {

            Instantiate<InputManager> ();
            Instantiate<UIManager> ();
        }

        private static void Instantiate<T> () where T : Component {

            GameObject g = new GameObject (typeof (T).Name);
            g.AddComponent<T> ();
            DontDestroyOnLoad (g);
        }
    }
}