using System.Collections;
using System.Collections.Generic;
using Birdwatcher.Procedural.Database;
using Birdwatcher.Procedural.Enum;
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

        public GameObject ConstructBird (Bird bird) {

            SetDatabases (bird);

            var beakGO = beakDb.GetRandomPart (bird.seed);
            var bodyGO = bodyDb.GetRandomPart (bird.seed);
            var wingGO = wingDb.GetRandomPart (bird.seed);
            var legsGO = legsDb.GetRandomPart (bird.seed);
            var tailGO = tailDb.GetRandomPart (bird.seed);

            GameObject instantiatedBody = Instantiate (bodyGO);
            CreatePart (beakGO, instantiatedBody.transform.Find (BEAK_SLOT));
            CreatePart (wingGO, instantiatedBody.transform.Find (WING_SLOT));
            CreatePart (legsGO, instantiatedBody.transform.Find (LEG_SLOT));
            CreatePart (tailGO, instantiatedBody.transform.Find (TAIL_SLOT));

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

            beakDb = Bunker.birdBeakDatabases.GetSpecificType (birdToData.Beak);
            bodyDb = Bunker.birdBodyDatabases.GetSpecificType (birdToData.Body);
            wingDb = Bunker.birdWingDatabases.GetSpecificType (birdToData.Wing);
            legsDb = Bunker.birdLegsDatabases.GetSpecificType (birdToData.Legs);
            tailDb = Bunker.birdTailDatabases.GetSpecificType (birdToData.Tail);
        }
    }
}
