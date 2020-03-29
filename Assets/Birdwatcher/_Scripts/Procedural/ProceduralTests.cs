using Birdwatcher.Procedural.Database;
using Birdwatcher.Procedural.Enum;
using Birdwatcher.Procedural.Generator;
using UnityEngine;

public class ProceduralTests : MonoBehaviour {

    [SerializeField, Range (-6000, 6000)]
    private int seed;

    [ContextMenu ("Generate Bird")]
    void Generate () {

        //Bird bird = BirdGenerator.GenerateBird (seed);
        Bunker.LoadDatabases ();
        Bird bird = new Bird (Beak.GENERALIST, Body.MEDIUM, Wing.FAST, Legs.GENERIC, Tail.BASIC, seed);
        print ($"{bird.Beak} \n{bird.Body} \n{bird.Wing} \n{bird.Legs} \n{bird.Tail} ");

        FindObjectOfType<BirdConstructor> ().ConstructBird (bird);
    }
}
