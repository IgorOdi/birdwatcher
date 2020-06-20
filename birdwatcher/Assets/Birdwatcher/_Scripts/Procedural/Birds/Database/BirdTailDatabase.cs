using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Birds.Database
{
    [CreateAssetMenu (fileName = "New Tail Database", menuName = "Database/Bird/Tail")]
    public class BirdTailDatabase : BirdPartDatabase<Tail> { }
}