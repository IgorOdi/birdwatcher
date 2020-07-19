using System.Collections.Generic;
using Birdwatcher.Global;
using UnityEngine;

namespace Birdwatcher.Input {

    public class InputManager : MonoBehaviour {

        private Dictionary<BirdKeys, InputKey> registeredKeys = new Dictionary<BirdKeys, InputKey> ();

        private static readonly List<string> KEY_AXIS = new List<string> { "Horizontal", "Vertical" };
        private static readonly List<string> MOUSE_AXIS = new List<string> { "Mouse X", "Mouse Y", "Mouse ScrollWheel" };

        public void Initialize () => this.SubscribeAsSingleton ();

        public InputKey RegisterKey (BirdKeys keyID, KeyCode keyCode) {

            var newKey = new InputKey (keyCode);
            registeredKeys[keyID] = newKey;
            return newKey;
        }

        public void UnregisterKey (BirdKeys keyID) {

            registeredKeys.Remove (keyID);
        }

        public InputKey GetKey (BirdKeys keyID) {

            return registeredKeys[keyID];
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

            foreach (KeyValuePair<BirdKeys, InputKey> pair in registeredKeys) {

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