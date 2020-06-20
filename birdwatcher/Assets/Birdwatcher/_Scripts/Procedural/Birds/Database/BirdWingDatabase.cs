using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Birds.Database
{
    [CreateAssetMenu (fileName = "New Wing Database", menuName = "Database/Bird/Wing")]
    public class BirdWingDatabase : BirdPartDatabase<Wing> { }
}