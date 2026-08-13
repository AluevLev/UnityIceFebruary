namespace UnityIceFebruary.HelpTools.AutoGenerator
{
    using System.ComponentModel;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ProxyType
    {
        None,
        Proxy,
        FieldProxy,
        InterfaceProxy,
        GenericVariantProxy,
        DataObjectProxy,
        StaticProxy
    }
}
