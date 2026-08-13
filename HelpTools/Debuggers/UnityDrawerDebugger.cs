#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using System.ComponentModel;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UnityDrawerDebugger
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void WarnAboutUnkonwnShape() => Debugger.Log("Unknown shape!", LogType.Warning);
    }
}
#endif
