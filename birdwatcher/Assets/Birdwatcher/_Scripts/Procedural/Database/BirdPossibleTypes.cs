using System.Collections.Generic;
using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    [CreateAssetMenu (fileName = "New Possible Type DB", menuName = "Database/Birds/Possible Types")]
    public class BirdPossibleTypes : ScriptableObject {

        public BirdType BirdType;

        public List<Beak> PossibleBeaks = new List<Beak> ();
        public List<Body> PossibleBodies = new List<Body> ();
        public List<Wing> PossibleWings = new List<Wing> ();
        public List<Legs> PossibleLegs = new List<Legs> ();
        public List<Tail> PossibleTails = new List<Tail> ();
    }
}