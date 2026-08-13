namespace UnityIceFebruary.InterfaceImplementation
{
    using System;
    using System.ComponentModel;
    using UnityEngine;

    [AttributeUsage(AttributeTargets.Field), EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class InterfaceImplementation : PropertyAttribute { }
}
