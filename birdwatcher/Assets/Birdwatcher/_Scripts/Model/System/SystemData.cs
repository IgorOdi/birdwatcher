using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdwatcher.Model.System {

    public class SystemData : BaseData {

        public float MusicVolume { get; private set; } = 1;
        public float SFXVolume { get; private set; } = 1;

        public int Language { get; private set; }
        public int Resolution { get; private set; }
        public int Quality { get; private set; }

        public int FontStyle { get; private set; }
        public int FontSize { get; private set; }
        public int ColorBlindness { get; private set; }

        public float Sensibility { get; private set; } = 3f;
    }
}