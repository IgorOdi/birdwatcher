using Birdwatcher.Global;
using Birdwatcher.Utils;
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
            Log.V ($"Loaded {this.GetType().Name}");
        }

        public virtual void OnUnload () {

            IsLoaded = false;
            Log.V ($"Unloaded {this.GetType().Name}");
        }
    }
}