namespace UnityIceFebruary.Adaptation
{
    using System.Runtime.CompilerServices;

    using IceLayerMask = IceFebruary.Physics.LayerMask;
    using UnityLayerMask = UnityEngine.LayerMask;

    /// <summary>
    /// Static class for converting <see cref="IceLayerMask"/> structure to <see cref="UnityLayerMask"/> and back.
    /// </summary>
    public static class UnityLayerMaskConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IceLayerMask ToIce(this UnityLayerMask layerMask) => new(layerMask.value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityLayerMask ToUnity(this IceLayerMask layerMask) => layerMask.Mask;
    }
}
