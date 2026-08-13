#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using UnityEngine;

    /// <summary>
    /// Static class for outputting logs to the console.
    /// </summary>
    public static class Debugger
    {
        /// <summary>
        /// Displays a message in the console.
        /// </summary>
        public static void Log(string message, LogType logType = LogType.Message)
        {
            switch (logType)
            {
                case LogType.Message:
                    Debug.Log(message);
                    break;

                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;

                case LogType.Error:
                    Debug.LogError(message);
                    break;
            }
        }
    }
}
#endif
