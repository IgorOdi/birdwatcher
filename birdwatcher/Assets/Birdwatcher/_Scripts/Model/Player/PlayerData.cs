using UnityEngine;

namespace Birdwatcher.Model.Player {

    [System.Serializable]
    public class PlayerData {

        [SerializeField]
        private float Speed;
        private float SlowedSpeed {
            get { return Speed / 2; }
            set { }
        }

        public float GetSpeed (bool isObserving) {

            return isObserving ? SlowedSpeed : Speed;
        }
    }
}