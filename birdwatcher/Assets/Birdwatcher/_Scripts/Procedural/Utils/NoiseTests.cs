using UnityEngine;

namespace Birdwatcher.Procedural.Utils {

    public class NoiseTests : MonoBehaviour {

        public MeshRenderer groundRenderer;

        public int width;
        public int height;
        public int octaves;

        public float scale;
        public float persistence;
        public float lacunarity;

        void OnValidate () {

            GenerateTexture ();
        }

        [ContextMenu ("GenerateTexture")]
        public void GenerateTexture () {

            float[, ] heightMap = NoiseGenerator.GenerateNoisemap (width, height, scale, octaves, persistence, lacunarity, 0);
            Texture2D texture = TextureGenerator.TextureFromHeightMap (heightMap);
            groundRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}