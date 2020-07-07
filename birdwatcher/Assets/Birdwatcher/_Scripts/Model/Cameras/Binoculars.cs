namespace Birdwatcher.Model.Cameras {

    public class Binoculars {

        public float MinZoom { get; }
        public float MaxZoom { get; }
        public float FocusPoint { get; set; }

        public Binoculars (float minZoom, float maxZoom) {

            MinZoom = minZoom;
            MaxZoom = maxZoom;
        }
    }
}