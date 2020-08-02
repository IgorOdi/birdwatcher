using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Tail Database", menuName = "Database/Birds/Parts/Tail")]
    public class BirdTailDatabase : BirdPartDatabase<Tail> { }
}