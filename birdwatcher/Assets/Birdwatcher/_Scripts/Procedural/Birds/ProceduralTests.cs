using Birdwatcher.Procedural.Birds.Database;
using Birdwatcher.Model.Birds;
using Birdwatcher.Procedural.Birds.Generator;
using UnityEngine;

public class ProceduralTests : MonoBehaviour {

    [SerializeField, Range (0, 12000)]
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
