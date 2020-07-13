using Birdwatcher.Model.Birds;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Birdwatcher.UI.Journal {

    public class ObservationSlot : MonoBehaviour {

        [SerializeField] private Image picture;
        [SerializeField] private new TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI type;
        [SerializeField] private TextMeshProUGUI height;
        [SerializeField] private TextMeshProUGUI weight;
        [SerializeField] private TextMeshProUGUI population;

        public void SetObservationInfo (Observable species) {

            name.text = species.Name;
            type.text = species.Type.ToString ();

            height.text = "10cm";
            weight.text = "1kg";
            population.text = "A";
        }
    }
}