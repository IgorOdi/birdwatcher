using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Tail Database", menuName = "Database/Parts/Bird/Tail")]
    public class BirdTailDatabase : BirdPartDatabase<Tail> { }
}