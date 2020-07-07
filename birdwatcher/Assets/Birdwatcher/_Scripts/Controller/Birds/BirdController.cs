using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Controller.Birds {

    [RequireComponent (typeof (Collider))]
    public class BirdController : MonoBehaviour, IObservable {

        public Observable Bird { get; set; }
        public Observable GetObservationData () => Bird;
    }
}