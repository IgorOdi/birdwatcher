using System;
using System.Collections.Generic;
using System.Reflection;
using Birdwatcher.Birds.Model;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    public static class Bunker {

        public static List<BirdPartDatabase<Beak>> birdBeakDatabases = new List<BirdPartDatabase<Beak>> ();
        public static List<BirdPartDatabase<Body>> birdBodyDatabases = new List<BirdPartDatabase<Body>> ();
        public static List<BirdPartDatabase<Wing>> birdWingDatabases = new List<BirdPartDatabase<Wing>> ();
        public static List<BirdPartDatabase<Legs>> birdLegsDatabases = new List<BirdPartDatabase<Legs>> ();
        public static List<BirdPartDatabase<Tail>> birdTailDatabases = new List<BirdPartDatabase<Tail>> ();

        public static void LoadDatabases () {

            birdBeakDatabases = DatabaseLoader.LoadDatabase<BirdBeakDatabase, Beak> ();
            birdBodyDatabases = DatabaseLoader.LoadDatabase<BirdBodyDatabase, Body> ();
            birdWingDatabases = DatabaseLoader.LoadDatabase<BirdWingDatabase, Wing> ();
            birdLegsDatabases = DatabaseLoader.LoadDatabase<BirdLegsDatabase, Legs> ();
            birdTailDatabases = DatabaseLoader.LoadDatabase<BirdTailDatabase, Tail> ();
        }

        public static BirdPartDatabase<T> GetSpecificType<T> (this List<BirdPartDatabase<T>> list, System.Enum specificType) where T : System.Enum {

            return list.Find (x => x.databaseType.Equals (specificType));
        }
    }
}