using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdwatcher.Procedural.Database {

    public static class DatabaseLoader {

        private static string BIRD_FOLDER = "Birds";

        public static List<BirdPartDatabase<T1>> LoadDatabase<T, T1> () where T1 : System.Enum {

            var loadedResources = Resources.LoadAll (BIRD_FOLDER, typeof (T));
            List<BirdPartDatabase<T1>> database = new List<BirdPartDatabase<T1>> ();
            foreach (var d in loadedResources)
                database.Add (d as BirdPartDatabase<T1>);

            if (database.Count == 0)
                throw new Exception ($"No {typeof(T1)} parts found");

            return database;
        }
    }
}