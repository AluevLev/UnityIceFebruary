namespace UnityIceFebruary.HelpTools.AutoGenerator
{
    using System;
    using System.IO;
    using System.Linq;
    using UnityEngine;

    public static class ProxyDirectory
    {
        private static readonly string _autoGenerationDirectoryPath = GetFullDirectory("Auto Generated");
        private static readonly ProxyType[] _proxyTypes = ((ProxyType[])Enum.GetValues(typeof(ProxyType)))
            .Where(proxyType => proxyType != ProxyType.None)
            .ToArray();
        public static string GetPath(ProxyType proxyTypes)
        {
            string folder = proxyTypes switch
            {
                ProxyType.Proxy => "Proxy",
                ProxyType.FieldProxy => "Field Proxy",
                ProxyType.InterfaceProxy => "Interface Proxy",
                ProxyType.GenericVariantProxy => "Generic Variant Proxy",
                ProxyType.ScriptableObjectProxy => "Scriptable Object Proxy",
                ProxyType.StaticProxy => "Static Dictionaries",
                _ => null
            };

            return folder == null ? null : Path.Combine(_autoGenerationDirectoryPath, folder);
        }
        public static void RecoveryDirectories()
        {
            RecoveryDirectory(_autoGenerationDirectoryPath);

            foreach (ProxyType path in _proxyTypes)
                RecoveryDirectory(GetPath(path));
        }
        private static void RecoveryDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
        private static string GetFullDirectory(string directory) => Path.Combine(Application.dataPath, directory);
    }
}
