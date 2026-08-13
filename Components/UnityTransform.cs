namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Transform = UnityEngine.Transform;

    /// <summary>
    /// Bridge component for controlling the Unity transform.
    /// </summary>
    public sealed class UnityTransform : UnityBaseEntity<Transform>, ITransform
    {
        /// <summary>
        /// Creates a new component for controlling the Unity transform.
        /// </summary>
        [FieldProxy(typeof(ITransform))]
        public UnityTransform(Transform transform) : base(transform) { }

        /// <summary>
        /// Position of the game object in the world.
        /// </summary>
        public Vector2 Position
        {
            get => Original.position.ToIce();
            set => Original.position = value.ToUnity();
        }

        /// <summary>
        /// Rotation of the game object in the world.
        /// </summary>
        public Rotor2 Rotation
        {
            get => Original.rotation.ToIce();
            set => Original.rotation = value.ToUnity();
        }

        /// <summary>
        /// Local position of the game object.
        /// </summary>
        public Vector2 LocalPosition
        {
            get => Original.localPosition.ToIce();
            set => Original.localPosition = value.ToUnity();
        }

        /// <summary>
        /// Local rotation of the game object.
        /// </summary>
        public Rotor2 LocalRotation
        {
            get => Original.localRotation.ToIce();
            set => Original.localRotation = value.ToUnity();
        }

        /// <summary>
        /// Local scale of the game object.
        /// </summary>
        public Vector2 LocalScale
        {
            get => Original.localScale.ToIce();
            set => Original.localScale = value.ToUnity();
        }

        /// <summary>
        /// Compute a direction by transforming coordinates in the target transformation space.
        /// </summary>
        public Vector2 TransformDirection(Vector2 v) => Original.TransformDirection(v.ToUnity()).ToIce();

        /// <summary>
        /// Compute a point by transforming coordinates in the target transformation space.
        /// </summary>
        public Vector2 TransformPoint(Vector2 v) => Original.TransformPoint(v.ToUnity()).ToIce();
    }
}
