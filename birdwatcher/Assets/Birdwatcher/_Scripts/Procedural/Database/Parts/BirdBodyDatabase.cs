using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Body Database", menuName = "Database/Birds/Parts/Body")]
    public class BirdBodyDatabase : BirdPartDatabase<Body> { }
}