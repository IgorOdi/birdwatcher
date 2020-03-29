using Birdwatcher.Procedural.Enum;

namespace Birdwatcher.Procedural.Generator {

    public class Bird {

        public string BirdName { get; private set; }

        public Beak Beak { get; private set; }
        public Body Body { get; private set; }
        public Wing Wing { get; private set; }
        public Legs Legs { get; private set; }
        public Tail Tail { get; private set; }

        public int seed { get; private set; }

        public Bird (Beak beak, Body body, Wing wing, Legs legs, Tail tail, int seed) {

            this.Beak = beak;
            this.Body = body;
            this.Wing = wing;
            this.Legs = legs;
            this.Tail = tail;
            this.seed = seed;
        }
    }
}