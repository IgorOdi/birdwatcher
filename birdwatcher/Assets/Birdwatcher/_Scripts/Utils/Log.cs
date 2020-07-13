using System.Diagnostics;

namespace Birdwatcher.Utils {

    public class Log {

        public static void V (object message) {

            StackTrace stackTrace = new StackTrace ();
            var classCaller = stackTrace.GetFrame (1).GetMethod ().DeclaringType.Name;
            var methodCaller = stackTrace.GetFrame (1).GetMethod ().Name;
            
            if (IsCoroutine (classCaller)) FormatAsCoroutine (ref classCaller);
            UnityEngine.Debug.Log ($"<b>[ {classCaller} | {methodCaller} ]</b> {message.ToString()}");
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