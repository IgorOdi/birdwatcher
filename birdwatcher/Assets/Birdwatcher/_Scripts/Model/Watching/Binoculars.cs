using System;
using UnityEngine;

namespace Birdwatcher.Model.Watching {

    public class Binoculars {

        public float MinRange { get; set; }
        public float MaxRange { get; set; }

        public Binoculars (float minRange, float maxRange) {

            MinRange = minRange;
            MaxRange = maxRange;
        }
    }
}