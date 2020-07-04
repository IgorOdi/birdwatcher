using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    [CreateAssetMenu (fileName = "New Beak Database", menuName = "Database/Parts/Bird/Beak")]
    public class BirdBeakDatabase : BirdPartDatabase<Beak> { }
}