using System.Diagnostics;
using UnityEngine;

namespace Birdwatcher.Utils {

    public class Log {

        public static void V (object message) {

            InternalVerbose (message, Color.black);
        }

        public static void V (object message, Color infoColor) {

            InternalVerbose (message, infoColor);
        }

        public static void InternalVerbose (object message, Color color) {

            StackTrace stackTrace = new StackTrace ();
            var classCaller = stackTrace.GetFrame (1).GetMethod ().DeclaringType.Name;
            var methodCaller = stackTrace.GetFrame (1).GetMethod ().Name;

            string colorString = ColorUtility.ToHtmlStringRGBA (color);

            if (IsCoroutine (classCaller)) FormatAsCoroutine (ref classCaller);
            UnityEngine.Debug.Log ($"<color=#{colorString}><b>[ {classCaller} | {methodCaller} ]</b></color> {message.ToString()}");
        }

        private static bool IsCoroutine (string text) {

            return text.Contains ("<");
        }

        private static void FormatAsCoroutine (ref string coroutineName) {

            coroutineName = coroutineName.Substring (coroutineName.IndexOf ("<") + 1, coroutineName.IndexOf (">") - 1);
            coroutineName = $"{coroutineName} Coroutine";
        }
    }
}