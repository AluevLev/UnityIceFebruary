#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using IceFebruary.Space;

    public static class MousePositionFinderDebugger
    {
        public static void DebugMousePosition(Vector2 position) => Debugger.Log($"Mouse Position: {position}");
        public static void WarnAboutInsolvencyToDebugCoordinates() => Debugger.Log("The scene window is not active or could not be found", LogType.Warning);
    }
}
#endif
