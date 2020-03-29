using System.Collections.Generic;
using System.Linq;
using Birdwatcher.Input.Enum;
using UnityEngine;

namespace Birdwatcher.Input {

    public class InputManager : MonoBehaviour {

        private Dictionary<RegistrableKeys, InputKey> registeredKeys = new Dictionary<RegistrableKeys, InputKey> ();

        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        public void RegisterKey (RegistrableKeys keyID, KeyCode keyCode) {

            if (registeredKeys.ContainsKey (keyID))
                throw new System.Exception ("Key já registrada");

            registeredKeys.Add (keyID, new InputKey (keyCode));
        }

        public float GetAxis (Axis axis, bool raw = true) {

            return raw ? UnityEngine.Input.GetAxisRaw (AxisToString (axis)) : UnityEngine.Input.GetAxis (AxisToString (axis));
        }

        public InputKey GetKey (RegistrableKeys keyID) {

            return registeredKeys.Where (x => x.Value.Equals (keyID)).FirstOrDefault ().Value;
        }

        private string AxisToString (Axis axis) {

            return axis.Equals (Axis.HORIZONTAL) ? HORIZONTAL : VERTICAL;
        }

        private void Update () {

            foreach (KeyValuePair<RegistrableKeys, InputKey> pair in registeredKeys) {

                if (UnityEngine.Input.GetKeyDown (pair.Value.KeyCode))
                    pair.Value.KeyDown ();

                if (UnityEngine.Input.GetKeyUp (pair.Value.KeyCode))
                    pair.Value.KeyUp ();

                if (UnityEngine.Input.GetKey (pair.Value.KeyCode))
                    pair.Value.KeyHold ();
            }
        }
    }
}