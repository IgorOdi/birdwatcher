using System;
using System.Collections.Generic;
using System.Linq;
using Birdwatcher.Global;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Birdwatcher.UI {

    [DefaultExecutionOrder(-1)]
    public class UIManager : MonoBehaviour {

        private Dictionary<UIData, UIController> uiList = new Dictionary<UIData, UIController> ();

        void Awake () => this.SubscribeAsSingleton ();

        public void LoadUI (UIData uiData, Action<UIController> callback = null) {

            SceneManager.LoadSceneAsync (uiData.SceneName, LoadSceneMode.Additive).completed += (operation) => {

                var loadedScene = SceneManager.GetSceneByName (uiData.SceneName);
                foreach (GameObject g in loadedScene.GetRootGameObjects ()) {

                    if (g.TryGetComponent<UIController> (out UIController controller)) {

                        callback?.Invoke (controller);
                        uiList.Add (uiData, controller);
                        return;
                    }
                }

                throw new Exception ("No UI controller was found on the loaded scene");
            };
        }

        public UIController GetUIController<T> () {

            return uiList.Values.Where (ui => ui.GetType () == typeof (T)).First ();
        }

        public void UnloadUI (UIData uiData, Action callback = null) {

            SceneManager.UnloadSceneAsync (uiData.SceneName, UnloadSceneOptions.None).completed += (operation) => {

                callback?.Invoke ();
            };
        }

        public void UnloadAll () {

            foreach (UIData ui in uiList.Keys) {

                UnloadUI (ui);
            }
        }
    }
}