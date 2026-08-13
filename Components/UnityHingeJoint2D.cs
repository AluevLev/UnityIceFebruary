namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Proxy;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using HingeJoint2D = UnityEngine.HingeJoint2D;

    /// <summary>
    /// Bridge component for controlling the Unity hinge joint.
    /// </summary>
    public sealed class UnityHingeJoint2D : UnityBaseEntity<HingeJoint2D>, IHingeJoint2D
    {
        /// <summary>
        /// Creates a new component for controlling the Unity hinge joint.
        /// </summary>
        [FieldProxy(typeof(IHingeJoint2D))]
        public UnityHingeJoint2D(HingeJoint2D hingeJoint2D) : base(hingeJoint2D) { }

        /// <summary>
        /// Joint anchor.
        /// </summary>
        public Vector2 Anchor
        {
            get => Original.anchor.ToIce();
            set => Original.anchor = value.ToUnity();
        }

        /// <summary>
        /// Body attached to joint.
        /// </summary>
        public IRigidbody2D ConnectedBody
        {
            get => UnityMethods.Upsert<UnityEngine.Rigidbody2D, IRigidbody2D>(Original.connectedBody);
            set => Original.connectedBody = (value as UnityRigidbody2D)?.Original;
        }
    }
}
