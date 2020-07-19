using System;
using UnityEngine;

namespace Birdwatcher.Input {

    public class InputKey {

        public KeyCode KeyCode { get; private set; }
        public float KeyValue { get; private set; }

        public Action OnKeyDown { get; set; }
        public Action OnKeyUp { get; set; }
        public Action OnKeyHold { get; set; }

        public InputKey (KeyCode keyCode) {

            this.KeyCode = keyCode;
        }

        public void KeyDown () {

            KeyValue = 1;
            OnKeyDown?.Invoke ();
        }

        public void KeyUp () {

            KeyValue = 0;
            OnKeyUp?.Invoke ();
        }

        public void KeyHold () {

            KeyValue = 1;
            OnKeyHold?.Invoke ();
        }
    }
}