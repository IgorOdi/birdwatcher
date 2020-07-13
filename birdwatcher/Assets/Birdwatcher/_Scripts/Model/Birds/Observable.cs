using System.Collections.Generic;

namespace Birdwatcher.Model.Birds {

    public class Observable {

        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class ObservableEqualityComparer : IEqualityComparer<Observable> {

        public bool Equals (Observable x, Observable y) {

            return x.Name.Equals (y.Name) && x.Type.Equals (y.Type);
        }

        public int GetHashCode (Observable obj) {

            return obj.GetHashCode ();
        }
    }
}