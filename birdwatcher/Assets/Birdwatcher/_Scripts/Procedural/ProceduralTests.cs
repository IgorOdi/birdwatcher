using System.Collections.Generic;
using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Database;
using Birdwatcher.Procedural.Generator;
using Birdwatcher.Utils;
using UnityEngine;

public class ProceduralTests : MonoBehaviour {

    [SerializeField, Range (0, 12000)]
    private int seed;
    [SerializeField]
    private BirdType birdType;

    [ContextMenu ("Generate Bird")]
    void GenerateBird () {

        Bunker.LoadPossibilities ();
        Bird bird = BirdGenerator.GenerateBird (birdType, seed);
        Log.V ($"{bird.Beak}, {bird.Body}, {bird.Wing}, {bird.Legs}, {bird.Tail}");
    }

    [ContextMenu ("Construct Bird")]
    void Generate () {

        Bunker.LoadDatabases ();
        Bird bird = new Bird (BirdType.GROUNDBIRD, Beak.GENERALIST, Body.MEDIUM, Wing.FAST, Legs.GENERIC, Tail.BASIC, seed);
        FindObjectOfType<BirdConstructor> ().ConstructBird (bird);
    }

    [ContextMenu ("Test Possibility")]
    void TestPossibilities () {

        var possibilities = DatabaseLoader.LoadPossibilities (BirdType.SKYBIRD);
        Log.V (possibilities.PossibleBeaks[0]);
    }

    void Awake () => SpawnTestBirds ();
    void SpawnTestBirds () {

        Bunker.LoadPossibilities ();
        Bunker.LoadDatabases ();
        List<Bird> birdList = new List<Bird> ();
        for (int i = 0; i <= 5435; i += 5435) {

            birdList.Add (new Bird (BirdType.GROUNDBIRD, Beak.GENERALIST, Body.MEDIUM, Wing.FAST, Legs.GENERIC, Tail.BASIC, i));
        }

        int birdAmount = Random.Range (4, 12);
        for (int i = 0; i < birdAmount; i++) {

            int birdIndex = i % 2 == 0 ? 0 : 1;
            var spawnedBird = FindObjectOfType<BirdConstructor> ().ConstructBird (birdList[birdIndex]);
            spawnedBird.transform.position = new Vector3 (Random.Range (-100, 100), Random.Range (1, 12), Random.Range (-100, 100));
        }
    }
}