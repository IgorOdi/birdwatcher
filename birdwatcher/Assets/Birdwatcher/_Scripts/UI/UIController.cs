using Birdwatcher.Global;
using UnityEngine;

namespace Birdwatcher.UI {

    public abstract class UIData {

        public virtual string SceneName { get; }
    }

    public abstract class UIController : MonoBehaviour {

        public bool IsLoaded { get; private set; }
        protected UIManager uiManager;

        public virtual void OnLoad () {

            IsLoaded = true;
            uiManager = SingletonManager.GetSingleton<UIManager> ();
            Debug.Log ($"Loaded {this.GetType().Name}");
        }

        public virtual void OnUnload () {

            IsLoaded = false;
            Debug.Log ($"Unloaded {this.GetType().Name}");
        }
    }
}