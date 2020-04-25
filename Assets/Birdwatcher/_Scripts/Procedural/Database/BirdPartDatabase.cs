using System.Collections.Generic;
using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    public class BirdPartDatabase<T> : ScriptableObject where T : System.Enum {

        public T databaseType;

        [SerializeField]
        protected List<GameObject> partList = new List<GameObject> ();

        public static int GetLength () {

            return System.Enum.GetValues (typeof (T)).Length;
        }

        public GameObject GetRandomPart (int seed) {

            System.Random r = new System.Random (seed);
            return partList[r.Next (0, partList.Count)];
        }

        public GameObject GetRandomPart () {

            System.Random r = new System.Random ();
            return partList[r.Next (0, partList.Count)];
        }
    }
}