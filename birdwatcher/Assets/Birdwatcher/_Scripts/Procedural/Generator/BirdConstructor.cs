using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Database;
using UnityEngine;

namespace Birdwatcher.Procedural.Generator {

    public class BirdConstructor : MonoBehaviour {

        private BirdPartDatabase<Beak> beakDb;
        private BirdPartDatabase<Body> bodyDb;
        private BirdPartDatabase<Wing> wingDb;
        private BirdPartDatabase<Legs> legsDb;
        private BirdPartDatabase<Tail> tailDb;

        private const string BEAK_SLOT = "BeakSlot";
        private const string WING_SLOT = "WingSlot";
        private const string LEG_SLOT = "LegSlot";
        private const string TAIL_SLOT = "TailSlot";

        [SerializeField]
        private Material mainMaterial;

        public GameObject ConstructBird (Bird bird) {

            SetDatabases (bird);

            System.Random random = new System.Random (bird.Seed);

            var beakGO = beakDb.GetRandomPart (random.Next ());
            var bodyGO = bodyDb.GetRandomPart (random.Next ());
            var wingGO = wingDb.GetRandomPart (random.Next ());
            var legsGO = legsDb.GetRandomPart (random.Next ());
            var tailGO = tailDb.GetRandomPart (random.Next ());

            GameObject instantiatedBody = Instantiate (bodyGO);
            CreatePart (beakGO, instantiatedBody.transform.Find (BEAK_SLOT));
            CreatePart (wingGO, instantiatedBody.transform.Find (WING_SLOT));
            CreatePart (legsGO, instantiatedBody.transform.Find (LEG_SLOT));
            CreatePart (tailGO, instantiatedBody.transform.Find (TAIL_SLOT));

            var collider = instantiatedBody.AddComponent<SphereCollider> ();
            collider.radius = 2f;

            instantiatedBody.AddComponent<Controller.Birds.BirdController> ().Bird = bird;
            foreach (MeshRenderer r in instantiatedBody.GetComponentsInChildren<MeshRenderer> ()) {

                r.material = mainMaterial;
            }

            return instantiatedBody;
        }

        private void CreatePart (GameObject part, Transform slot) {

            GameObject instantiatedPart = Instantiate (part);
            instantiatedPart.transform.SetParent (slot);
            instantiatedPart.transform.position = slot.position;
            instantiatedPart.transform.eulerAngles = slot.eulerAngles;
            instantiatedPart.transform.localScale = Vector3.one;
        }

        private void SetDatabases (Bird birdToData) {

            beakDb = Bunker.birdBeakDatabases.GetDatabase (birdToData.Beak);
            bodyDb = Bunker.birdBodyDatabases.GetDatabase (birdToData.Body);
            wingDb = Bunker.birdWingDatabases.GetDatabase (birdToData.Wing);
            legsDb = Bunker.birdLegsDatabases.GetDatabase (birdToData.Legs);
            tailDb = Bunker.birdTailDatabases.GetDatabase (birdToData.Tail);
        }
    }
}