using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database
{
    [CreateAssetMenu (fileName = "New Body Database", menuName = "Database/Bird/Body")]
    public class BirdBodyDatabase : BirdPartDatabase<Body> { }
}