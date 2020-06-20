using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Birds.Database
{
    [CreateAssetMenu (fileName = "New Body Database", menuName = "Database/Bird/Body")]
    public class BirdBodyDatabase : BirdPartDatabase<Body> { }
}