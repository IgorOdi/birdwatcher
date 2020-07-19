using System.Collections.Generic;
using Birdwatcher.Global;
using UnityEngine;
using UnityEngine.UI;

namespace Birdwatcher.UI
{

    public enum PauseButton {

        RESUME,
        JOURNAL,
        OPTIONS,
        CONTROLS,
        QUIT
    }

    public class PauseUIData : UIData {

        public override string SceneName { get { return "PauseMain"; } }
    }

    public class ClosedBookUIData : UIData {

        public override string SceneName { get { return "ClosedBook"; } }
    }

    public class OpenBookUIData : UIData {

        public override string SceneName { get { return "OpenBook"; } }
    }

    public class PauseController : UIController {

        [SerializeField]
        private List<Button> buttons = new List<Button> ();
        private UIController loadedPauseMenu;

        private OpenBookUIData openBookUiData = new OpenBookUIData ();
        private ClosedBookUIData closedBookUiData = new ClosedBookUIData ();
        private List<UIData> uiDatas = new List<UIData> {

            new Journal.JournalUIData (),
            new ClosedBookUIData (),
            new ClosedBookUIData (),
        };

        public override void OnLoad () {

            base.OnLoad ();
            buttons[(int) PauseButton.RESUME].onClick.AddListener (OnResumeClick);
            buttons[(int) PauseButton.JOURNAL].onClick.AddListener (delegate { OnMenuButtonClick (uiDatas[0]); });
            buttons[(int) PauseButton.OPTIONS].onClick.AddListener (delegate { OnMenuButtonClick (uiDatas[1]); });
            buttons[(int) PauseButton.CONTROLS].onClick.AddListener (delegate { OnMenuButtonClick (uiDatas[2]); });
            buttons[(int) PauseButton.QUIT].onClick.AddListener (OnQuitClick);

            SingletonManager.GetSingleton<GameManager> ().ToggleCursor (locked: false);
        }

        public void UnloadPauseMenus () {

            uiManager.UnloadUI (this);
            if (loadedPauseMenu != null) {

                uiManager.UnloadUI (openBookUiData);
                uiManager.UnloadUI (loadedPauseMenu);
            }
            SingletonManager.GetSingleton<GameManager> ().ToggleCursor (locked: true);
        }

        private void OnResumeClick () {

            UnloadPauseMenus ();
        }

        private void OnMenuButtonClick (UIData uiData) {

            uiManager.LoadUI (openBookUiData, (bookController) => {

                uiManager.LoadUI (uiData, (controller) => { loadedPauseMenu = controller; });
            });
        }

        private void OnQuitClick () {

            Application.Quit ();
        }
    }
}