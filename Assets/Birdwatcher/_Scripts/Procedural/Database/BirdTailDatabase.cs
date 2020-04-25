using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Tail Database", menuName = "Database/Bird/Tail")]
    public class BirdTailDatabase : BirdPartDatabase<Tail> { }
}