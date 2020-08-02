using System;
using UnityEngine;

namespace Birdwatcher.Model.Player {

    [Serializable]
    public class PlayerData {

        [SerializeField]
        private float Speed;
        private float SlowedSpeed { get { return Speed / 2; } }

        public float GetSpeed (bool isObserving) {

            return isObserving ? SlowedSpeed : Speed;
        }
    }
}