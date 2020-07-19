using System.Collections.Generic;
using Birdwatcher.Global;
using Birdwatcher.Model.Birds;
using UnityEngine;
using UnityEngine.UI;

namespace Birdwatcher.UI.Journal
{

    public class JournalUIData : UIData {

        public override string SceneName { get { return "Journal"; } }
    }

    public class JournalController : UIController {

        [SerializeField]
        private List<ObservationSlot> birdSlots = new List<ObservationSlot> ();
        private List<IObservable> identifiedBirds = new List<IObservable> ();

        [SerializeField]
        private Button previousPageButton;
        [SerializeField]
        private Button nextPageButton;

        private int pageIndex;

        private int birdsPerPage { get { return birdSlots.Count; } }
        private int maxPages { get { return Mathf.FloorToInt (identifiedBirds.Count / (birdsPerPage + 1)); } }

        public override void OnLoad () {

            base.OnLoad ();
            identifiedBirds = SingletonManager.GetSingleton<GameManager> ().CurrentGameSession.IdentifiedSpecies;

            previousPageButton.onClick.AddListener (() => { RefreshPage (pageIndex -= 1); });
            nextPageButton.onClick.AddListener (() => { RefreshPage (pageIndex += 1); });

            RefreshPage (0);
        }

        public void RefreshPage (int newPageIndex) {

            birdSlots.ForEach ((slot) => slot.gameObject.SetActive (false));
            previousPageButton.gameObject.SetActive (pageIndex > 0);
            nextPageButton.gameObject.SetActive (pageIndex < maxPages);

            int startIndex = pageIndex * birdsPerPage;
            for (int i = 0, j = startIndex; i < birdsPerPage && j < identifiedBirds.Count; i++, j++) {

                birdSlots[i].gameObject.SetActive (true);
                birdSlots[i].SetObservationInfo (identifiedBirds[j].GetObservationData ());
            }
        }
    }
}