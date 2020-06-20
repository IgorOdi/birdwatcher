using System;
using UnityEngine;

namespace Birdwatcher.Procedural.Utils {

    public static class NoiseGenerator {

        public static float[, ] GenerateNoisemap (int width, int height, float scale, int octaveAmount, float persistence, float lacunarity, int seed) {

            float[, ] noiseMap = new float[width, height];

            System.Random rng = new System.Random (seed);

            Vector2[] octaveOffsets = new Vector2[octaveAmount];
            for (int i = 0; i < octaveAmount; i++) {

                float offsetX = rng.Next (-100000, 100000);
                float offsetY = rng.Next (-100000, 100000);
                octaveOffsets[i] = new Vector2 (offsetX, offsetY);
            }

            if (scale <= 0)
                scale = 0.0001f;

            float halfWidth = width / 2;
            float halfHeight = height / 2;

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {

                    float amplitude = 1f;
                    float frequency = 1f;
                    float noiseHeight = 0f;

                    for (int i = 0; i < octaveAmount; i++) {

                        float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                        float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                        var value = Mathf.PerlinNoise (sampleX, sampleY);
                        noiseHeight += value * amplitude;
                        amplitude *= 1 - persistence;
                        frequency *= lacunarity;
                    }

                    noiseHeight = Mathf.Clamp (noiseHeight, 0, 1);
                    noiseMap[x, y] = noiseHeight;
                }
            }

            return noiseMap;
        }
    }
}