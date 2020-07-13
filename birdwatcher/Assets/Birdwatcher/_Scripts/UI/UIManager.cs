using System;
using System.Collections.Generic;
using System.Linq;
using Birdwatcher.Global;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Birdwatcher.UI {

    public class UIManager : MonoBehaviour {

        private Dictionary<UIData, UIController> uiList = new Dictionary<UIData, UIController> ();

        public void Initialize () => this.SubscribeAsSingleton ();

        public void LoadUI (UIData uiData, Action<UIController> callback = null) {

            if (uiList.Keys.Where (u => u.SceneName == uiData.SceneName).FirstOrDefault () != null)
                throw new Exception ("This UI is already loaded");

            SceneManager.LoadSceneAsync (uiData.SceneName, LoadSceneMode.Additive).completed += (operation) => {

                var loadedScene = SceneManager.GetSceneByName (uiData.SceneName);
                foreach (GameObject g in loadedScene.GetRootGameObjects ()) {

                    if (g.TryGetComponent<UIController> (out UIController controller)) {

                        controller.OnLoad ();
                        callback?.Invoke (controller);
                        uiList.Add (uiData, controller);
                        return;
                    }
                }

                throw new Exception ("No UI controller was found on the loaded scene");
            };
        }

        public void UnloadUI (UIData uiData, Action callback = null) {

            GetUIController (uiData).OnUnload ();
            InternalUnload (uiData, callback);
        }

        public void UnloadUI (UIController uiController, Action callback = null) {

            uiController.OnUnload ();
            InternalUnload (GetUIDataFromController (uiController), callback);
        }

        public void UnloadAll () {

            foreach (UIData ui in uiList.Keys) {

                UnloadUI (ui);
            }
        }

        private void InternalUnload (UIData uiData, Action callback = null) {

            SceneManager.UnloadSceneAsync (uiData.SceneName, UnloadSceneOptions.None).completed += (operation) => {

                callback?.Invoke ();
                uiList.Remove (uiData);
            };
        }

        private UIController GetUIController (UIData uiData) {

            return uiList[uiData];
        }

        private UIData GetUIDataFromController (UIController uiController) {

            return uiList.Where (ui => ui.Value == uiController).First ().Key;
        }
    }
}