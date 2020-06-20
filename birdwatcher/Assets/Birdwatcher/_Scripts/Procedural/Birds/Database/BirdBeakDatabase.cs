using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Birds.Database {

    [CreateAssetMenu (fileName = "New Beak Database", menuName = "Database/Bird/Beak")]
    public class BirdBeakDatabase : BirdPartDatabase<Beak> { }
}