using System.Collections.Generic;
using Birdwatcher.Enum;
using UnityEngine;

namespace Birdwatcher.Database {

    public class BirdPartDatabase<T> : ScriptableObject {

        public T databaseType;
        [SerializeField]
        protected List<GameObject> partList = new List<GameObject> ();

        public GameObject GetRandomPart (int seed) {

            System.Random r = new System.Random (seed);
            return partList[r.Next (0, partList.Count)];
        }

        public GameObject GetRandomPart () {

            System.Random r = new System.Random ();
            return partList[r.Next (0, partList.Count)];
        }
    }

    [CreateAssetMenu (fileName = "New Beak Database", menuName = "Database/Bird/Beak")]
    public class BirdBeakDatabase : BirdPartDatabase<Beak> { }

    [CreateAssetMenu (fileName = "New Body Database", menuName = "Database/Bird/Body")]
    public class BirdBodyDatabase : BirdPartDatabase<Body> { }

    [CreateAssetMenu (fileName = "New Wing Database", menuName = "Database/Bird/Wing")]
    public class BirdWingDatabase : BirdPartDatabase<Wings> { }

    [CreateAssetMenu (fileName = "New Leg Database", menuName = "Database/Bird/Leg")]
    public class BirdLegDatabase : BirdPartDatabase<Legs> { }
}