using System.Collections;
using System.Collections.Generic;
using Birdwatcher.Global;
using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.UI.Journal {

    public class JournalUIData : UIData {

        public override string SceneName { get { return "Journal"; } }
    }

    public class JournalController : UIController {

        [SerializeField]
        private List<ObservationSlot> birdSlots = new List<ObservationSlot> ();
        private List<IObservable> identifiedBirds = new List<IObservable> ();

        private int pageIndex;

        private int birdsPerPage { get { return birdSlots.Count; } }
        private int maxPages { get { return Mathf.FloorToInt (identifiedBirds.Count / birdsPerPage); } }

        public override void OnLoad () {

            base.OnLoad ();
            identifiedBirds = SingletonManager.GetSingleton<GameManager> ().CurrentGameSession.IdentifiedSpecies;
            RefreshPage ();
        }

        public void RefreshPage () {

            birdSlots.ForEach ((slot) => slot.gameObject.SetActive (false));

            int startIndex = pageIndex * birdsPerPage;
            for (int i = 0, j = startIndex; i < birdsPerPage && j < identifiedBirds.Count; i++, j++) {

                birdSlots[i].gameObject.SetActive (true);
                birdSlots[i].SetObservationInfo (identifiedBirds[j].GetObservationData ());
            }
        }
    }
}