using System.Collections.Generic;
using Birdwatcher.Procedural.Enum;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    public class BirdPartDatabase<T> : ScriptableObject where T : System.Enum {

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
    public class BirdWingDatabase : BirdPartDatabase<Wing> { }

    [CreateAssetMenu (fileName = "New Leg Database", menuName = "Database/Bird/Leg")]
    public class BirdLegsDatabase : BirdPartDatabase<Legs> { }

    [CreateAssetMenu (fileName = "New Tail Database", menuName = "Database/Bird/Tail")]
    public class BirdTailDatabase : BirdPartDatabase<Tail> { }
}