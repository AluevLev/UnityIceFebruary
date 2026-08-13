#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ProxyGeneratorDebugger
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DebugInformationAboutProxyableTypes(int proxyableTypesCount, IEnumerable<Type> proxyableTypes)
        {
            Debugger.Log("Information about proxyable types:");
            Debugger.Log($"Number of types: {proxyableTypesCount}");
            Debugger.Log($"Types: \n{string.Join("\n", proxyableTypes.Select(type => type.Name))}");
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DebugGeneratedProxy(string fileName) => Debugger.Log($"Proxy generated: {fileName}");
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DebugSuccess() => Debugger.Log("Done!");
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void WarnAboutProxyableAbsence() => Debugger.Log("No proxyable types were found!", LogType.Warning);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void WarnAboutUnproxyableObject() => Debugger.Log("Cannot generate a proxy for an object with a non-proxied interface or an object that is not an interface!", LogType.Error);
    }
}
#endif
