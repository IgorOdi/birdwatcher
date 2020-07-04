using System;
using System.Collections.Generic;
using Birdwatcher.Model.Birds;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    internal static class DatabaseLoader {

        private static string BIRD_FOLDER = "Birds/Parts";
        private static string POSSIBILITIES_FOLDER = "Birds/Possibilities";

        internal static List<BirdPartDatabase<T1>> LoadDatabases<T, T1> () where T1 : System.Enum {

            var loadedResources = Resources.LoadAll (BIRD_FOLDER, typeof (T));
            List<BirdPartDatabase<T1>> database = new List<BirdPartDatabase<T1>> ();
            foreach (var d in loadedResources)
                database.Add (d as BirdPartDatabase<T1>);

            if (database.Count == 0)
                throw new Exception ($"No {typeof(T1)} parts found");

            return database;
        }

        internal static BirdPossibleTypes LoadPossibilities (BirdType birdType) {

            var loadedResources = Resources.LoadAll (POSSIBILITIES_FOLDER, typeof (BirdPossibleTypes));
            foreach (var l in loadedResources) {
                if ((l as BirdPossibleTypes).BirdType == birdType)
                    return l as BirdPossibleTypes;
            }

            throw new Exception ("No Possibilities File found.");
        }
    }
}