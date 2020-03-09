using Birdwatcher.Procedural.Database;
using Birdwatcher.Procedural.Enum;
using UnityEngine;

public class ProceduralTests : MonoBehaviour {

    void Start () {

        Bunker.LoadDatabases ();
        Debug.Log (Bunker.birdBeakDatabases.GetSpecificType (Beak.GENERALIST));
    }
}