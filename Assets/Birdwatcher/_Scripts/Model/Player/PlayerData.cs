using UnityEngine;

namespace Birdwatcher.Model.Player {

    [System.Serializable]
    public class PlayerData {

        [SerializeField]
        private float Speed;
        private float SlowedSpeed { get; set; }

        public PlayerData (float speed) {

            this.Speed = speed;
            this.SlowedSpeed = Speed / 2;
        }

        public float GetSpeed (bool isCrounched) {

            return isCrounched ? SlowedSpeed : Speed;
        }
    }
}