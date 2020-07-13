namespace Birdwatcher.Model.Birds {

    public class Bird : Observable {

        public readonly BirdType BirdType;

        public readonly Beak Beak;
        public readonly Body Body;
        public readonly Wing Wing;
        public readonly Legs Legs;
        public readonly Tail Tail;

        public readonly int Seed;

        public Bird (BirdType birdType, Beak beak, Body body, Wing wing, Legs legs, Tail tail, int seed) {

            this.Name = seed.ToString ();

            this.BirdType = birdType;
            this.Type = BirdType.ToString ();

            this.Beak = beak;
            this.Body = body;
            this.Wing = wing;
            this.Legs = legs;
            this.Tail = tail;

            this.Seed = seed;
        }
    }
}