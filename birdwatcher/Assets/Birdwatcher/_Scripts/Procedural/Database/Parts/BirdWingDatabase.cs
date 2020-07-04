using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Wing Database", menuName = "Database/Parts/Bird/Wing")]
    public class BirdWingDatabase : BirdPartDatabase<Wing> { }
}