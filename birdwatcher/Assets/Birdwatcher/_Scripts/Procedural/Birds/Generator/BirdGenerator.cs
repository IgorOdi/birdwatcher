using Birdwatcher.Procedural.Birds.Database;
using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Birds.Generator {

    public class BirdGenerator {

        private static int seedRange = 10000;

        public static Bird GenerateBird (int seed) {

            return InternalGenerate (seed);
        }

        public static Bird GenerateBird () {

            int seed = Random.Range (-seedRange, seedRange);
            return InternalGenerate (seed);
        }

        private static Bird InternalGenerate (int seed) {

            System.Random randomizer = new System.Random (seed);
            return new Bird (
                (Beak) randomizer.Next (0, BirdBeakDatabase.GetLength ()),
                (Body) randomizer.Next (0, BirdBodyDatabase.GetLength ()),
                (Wing) randomizer.Next (0, BirdWingDatabase.GetLength ()),
                (Legs) randomizer.Next (0, BirdLegsDatabase.GetLength ()),
                (Tail) randomizer.Next (0, BirdTailDatabase.GetLength ()),
                seed
            );
        }
    }
}
