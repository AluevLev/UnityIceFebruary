#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using IceFebruary.Space;
    using System.ComponentModel;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class MousePositionFinderDebugger
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DebugMousePosition(Vector2 position) => Debugger.Log($"Mouse Position: {position}");
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void WarnAboutInsolvencyToDebugCoordinates() => Debugger.Log("The scene window is not active or could not be found", LogType.Warning);
    }
}
#endif
