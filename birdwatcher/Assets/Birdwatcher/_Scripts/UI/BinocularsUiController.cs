using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Birdwatcher.UI {

    public class BinocularsUIData : UIData {

        public override string SceneName { get { return "BinocularsUI"; } }
    }

    public class BinocularsUiController : UIController {

        [SerializeField]
        private TextMeshProUGUI mainText;
        [SerializeField]
        private GameObject progressGameObject;
        [SerializeField]
        private Image progressBar;
        private Coroutine resetCoroutine;

        private const float BASE_RESET_TIME = 3f;

        protected override void Initialize () {

            base.Initialize ();
            ToggleProgressBar (active: false);
            SetProgressBar (0);
        }

        public void SetMainDisplay (string text, bool resetText = false, float resetTime = BASE_RESET_TIME) {

            mainText.text = text;
            if (resetText) {
                if (resetCoroutine != null) StopCoroutine (resetCoroutine);
                resetCoroutine = StartCoroutine (ResetMainDisplay (resetTime));
            }
        }

        public void SetProgressBar (float percent) {

            if (!progressGameObject.activeSelf) ToggleProgressBar (true);
            progressBar.fillAmount = percent;
        }

        public void ToggleProgressBar (bool active) {

            progressGameObject.SetActive (active);
        }

        private IEnumerator ResetMainDisplay (float resetTime) {

            yield return new WaitForSeconds (resetTime);
            mainText.text = "";
        }
    }
}