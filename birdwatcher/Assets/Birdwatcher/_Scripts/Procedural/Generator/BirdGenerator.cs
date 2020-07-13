using System;
using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Database;

namespace Birdwatcher.Procedural.Generator {

    public class BirdGenerator {

        private static int seedRange = 10000;

        public static Bird GenerateBird (BirdType birdType, int seed) {

            return InternalGenerate (birdType, seed);
        }

        public static Bird GenerateBird (BirdType birdType) {

            int seed = UnityEngine.Random.Range (-seedRange, seedRange);
            return InternalGenerate (birdType, seed);
        }

        public static Bird GenerateBird () {

            int seed = UnityEngine.Random.Range (-seedRange, seedRange);
            BirdType birdType = (BirdType) UnityEngine.Random.Range (0, Enum.GetNames (typeof (BirdType)).Length);
            return InternalGenerate (birdType, seed);
        }

        private static Bird InternalGenerate (BirdType birdType, int seed) {

            System.Random randomizer = new System.Random (seed);
            var possibilities = Bunker.GetPossibilities (birdType);

            return new Bird (
                birdType,
                (Beak) possibilities.PossibleBeaks[randomizer.Next (0, possibilities.PossibleBeaks.Count)],
                (Body) possibilities.PossibleBodies[randomizer.Next (0, possibilities.PossibleBodies.Count)],
                (Wing) possibilities.PossibleWings[randomizer.Next (0, possibilities.PossibleWings.Count)],
                (Legs) possibilities.PossibleLegs[randomizer.Next (0, possibilities.PossibleLegs.Count)],
                (Tail) possibilities.PossibleTails[randomizer.Next (0, possibilities.PossibleTails.Count)],
                seed
            );
        }
    }
}