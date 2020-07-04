using System;
using System.Collections.Generic;
using System.Linq;
using Birdwatcher.Model.Birds;

namespace Birdwatcher.Procedural.Database {

    internal static class Bunker {

        internal static List<BirdPartDatabase<Beak>> birdBeakDatabases = new List<BirdPartDatabase<Beak>> ();
        internal static List<BirdPartDatabase<Body>> birdBodyDatabases = new List<BirdPartDatabase<Body>> ();
        internal static List<BirdPartDatabase<Wing>> birdWingDatabases = new List<BirdPartDatabase<Wing>> ();
        internal static List<BirdPartDatabase<Legs>> birdLegsDatabases = new List<BirdPartDatabase<Legs>> ();
        internal static List<BirdPartDatabase<Tail>> birdTailDatabases = new List<BirdPartDatabase<Tail>> ();

        private static List<BirdPossibleTypes> birdPossibilities = new List<BirdPossibleTypes> ();

        internal static void LoadDatabases () {

            birdBeakDatabases = DatabaseLoader.LoadDatabases<BirdBeakDatabase, Beak> ();
            birdBodyDatabases = DatabaseLoader.LoadDatabases<BirdBodyDatabase, Body> ();
            birdWingDatabases = DatabaseLoader.LoadDatabases<BirdWingDatabase, Wing> ();
            birdLegsDatabases = DatabaseLoader.LoadDatabases<BirdLegsDatabase, Legs> ();
            birdTailDatabases = DatabaseLoader.LoadDatabases<BirdTailDatabase, Tail> ();
        }

        internal static void LoadPossibilities () {

            for (int i = 0; i < Enum.GetNames (typeof (BirdType)).Length; i++) {

                birdPossibilities.Add (DatabaseLoader.LoadPossibilities ((BirdType) i));
            }
        }

        internal static void UnloadDatabases () {

            birdBeakDatabases = null;
            birdBodyDatabases = null;
            birdWingDatabases = null;
            birdLegsDatabases = null;
            birdTailDatabases = null;
        }

        internal static void UnloadPossibilities () {

            birdPossibilities.Clear ();
        }

        internal static BirdPartDatabase<T> GetDatabase<T> (this List<BirdPartDatabase<T>> list, System.Enum specificType) where T : System.Enum {

            return list.Find (x => x.databaseType.Equals (specificType));
        }

        internal static BirdPossibleTypes GetPossibilities (BirdType birdType) {

            return birdPossibilities.Where (b => b.BirdType.Equals (birdType)).First ();
        }
    }
}