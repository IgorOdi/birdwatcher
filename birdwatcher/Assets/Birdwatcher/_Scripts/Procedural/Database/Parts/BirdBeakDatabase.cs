using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    [CreateAssetMenu (fileName = "New Beak Database", menuName = "Database/Birds/Parts/Beak")]
    public class BirdBeakDatabase : BirdPartDatabase<Beak> { }
}