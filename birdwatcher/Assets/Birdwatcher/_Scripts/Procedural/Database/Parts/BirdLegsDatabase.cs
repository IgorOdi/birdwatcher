using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Leg Database", menuName = "Database/Parts/Bird/Leg")]
    public class BirdLegsDatabase : BirdPartDatabase<Legs> { }
}