<<<<<<< HEAD
﻿using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Database;
=======
﻿using Birdwatcher.Procedural.Database;
using Birdwatcher.Model.Birds;
>>>>>>> feature/player
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

            System.Random random = new System.Random (bird.seed);

            var beakGO = beakDb.GetRandomPart (random.Next());
            var bodyGO = bodyDb.GetRandomPart (random.Next());
            var wingGO = wingDb.GetRandomPart (random.Next());
            var legsGO = legsDb.GetRandomPart (random.Next());
            var tailGO = tailDb.GetRandomPart (random.Next());

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