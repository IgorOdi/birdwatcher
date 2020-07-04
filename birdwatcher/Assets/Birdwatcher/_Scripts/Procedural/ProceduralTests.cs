using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Database;
using Birdwatcher.Procedural.Generator;
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
        Debug.Log ($"{bird.Beak}, {bird.Body}, {bird.Wing}, {bird.Legs}, {bird.Tail}");
    }

    [ContextMenu ("Construct Bird")]
    void Generate () {

        Bunker.LoadDatabases ();
        Bird bird = new Bird (Beak.GENERALIST, Body.MEDIUM, Wing.FAST, Legs.GENERIC, Tail.BASIC, seed);
        FindObjectOfType<BirdConstructor> ().ConstructBird (bird);
    }

    [ContextMenu ("Test Possibility")]
    void TestPossibilities () {

        var possibilities = DatabaseLoader.LoadPossibilities (BirdType.SKYBIRD);
        Debug.Log (possibilities.PossibleBeaks[0]);
    }
}