using System;
using System.Collections;
using UnityEngine;

namespace Birdwatcher.Utils {

    public static class TimeUtils {

        public static void RunDelayed (this MonoBehaviour mono, float delay, Action callback) {

            mono.StartCoroutine (DelayedCoroutine (delay, callback));
        }

        private static IEnumerator DelayedCoroutine (float delay, Action callback) {

            yield return new WaitForSeconds (delay);
            callback?.Invoke ();
        }
    }
}