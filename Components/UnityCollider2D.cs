namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Proxy;

    using Collider2D = UnityEngine.Collider2D;

    /// <summary>
    /// Bridge component for controlling the Unity collider.
    /// </summary>
    public sealed class UnityCollider2D : UnityBaseEntity<Collider2D>, ICollider2D
    {
        /// <summary>
        /// Creates a new component for controlling the Unity collider.
        /// </summary>
        [FieldProxy(typeof(ICollider2D))]
        public UnityCollider2D(Collider2D collider2D) : base(collider2D) { }
    }
}
