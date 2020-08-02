using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Leg Database", menuName = "Database/Birds/Parts/Leg")]
    public class BirdLegsDatabase : BirdPartDatabase<Legs> { }
}