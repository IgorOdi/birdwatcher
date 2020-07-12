using Birdwatcher.Global;
using UnityEngine;

namespace Birdwatcher.UI {

    public abstract class UIData {

        public virtual string SceneName { get; }
    }

    public abstract class UIController : MonoBehaviour {

        protected UIManager uiManager;
        protected bool isLoaded;

        void Awake () => Initialize ();

        protected virtual void Initialize () {

            uiManager = SingletonManager.GetSingleton<UIManager> ();
        }
    }
}