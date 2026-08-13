namespace UnityIceFebruary
{
    using IceFebruary;
    using System;
    using System.Runtime.CompilerServices;

    using UnityObject = UnityEngine.Object;

    /// <summary>
    /// Static class that converts Unity components into bridge components and stores them in a list.
    /// </summary>
    public static class UnityMethods
    {
        private static readonly ConditionalWeakTable<UnityObject, IBaseEntity> _objects = new();

        /// <summary>
        /// Returns an already converted Unity component from the list, or converts a Unity component to its bridge counterpart, adds it to the list, and returns it.
        /// </summary>
        public static TConversion Upsert<T, TConversion>(T unityObject) where T : UnityObject where TConversion : IBaseEntity => unityObject != null && UnityMatchObject.FabricAliases.TryGetValue(unityObject.GetType(), out Func<UnityObject, IBaseEntity> factory) ? (TConversion)_objects.GetValue(unityObject, obj => factory((T)obj)) : default;

        /// <summary>
        /// Removes the converted Unity component from the list, if it is there.
        /// </summary>
        public static void Remove<T>(UnityBaseEntity<T> analog) where T : UnityObject
        {
            if (analog != null)
                _objects.Remove(analog.Original);
        }
    }
}
