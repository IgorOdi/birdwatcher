using System.Collections.Generic;
using System.Linq;
using Birdwatcher.Global;
using UnityEngine;

namespace Birdwatcher.Input {

    [DefaultExecutionOrder(-1)]
    public class InputManager : MonoBehaviour {

        private Dictionary<RegistrableKeys, InputKey> registeredKeys = new Dictionary<RegistrableKeys, InputKey> ();

        private static readonly List<string> KEY_AXIS = new List<string> { "Horizontal", "Vertical" };
        private static readonly List<string> MOUSE_AXIS = new List<string> { "Mouse X", "Mouse Y", "Mouse ScrollWheel" };

        void Awake () => this.SubscribeAsSingleton ();

        public InputKey RegisterKey (RegistrableKeys keyID, KeyCode keyCode) {

            if (registeredKeys.ContainsKey (keyID))
                throw new System.Exception ("Key já registrada");

            var newKey = new InputKey (keyCode);
            registeredKeys.Add (keyID, newKey);
            return newKey;
        }

        public void UnregisterKey (RegistrableKeys keyID) {

            registeredKeys.Remove (keyID);
        }

        public InputKey GetKey (RegistrableKeys keyID) {

            return registeredKeys.Where (x => x.Value.Equals (keyID)).FirstOrDefault ().Value;
        }

        public float GetAxis (KeyAxis axis, bool raw = true) {

            return raw ? UnityEngine.Input.GetAxisRaw (KEY_AXIS[(int) axis]) : UnityEngine.Input.GetAxis (KEY_AXIS[(int) axis]);
        }

        public float GetMouseAxis (MouseAxis axis) {

            return UnityEngine.Input.GetAxis (MOUSE_AXIS[(int) axis]);
        }

        public void ClearKeys () {

            registeredKeys.Clear ();
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