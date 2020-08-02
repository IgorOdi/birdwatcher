using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Wing Database", menuName = "Database/Birds/Parts/Wing")]
    public class BirdWingDatabase : BirdPartDatabase<Wing> { }
}