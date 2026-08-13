namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Proxy;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Rigidbody2D = UnityEngine.Rigidbody2D;
    using UnityForceMode2D = UnityEngine.ForceMode2D;

    /// <summary>
    /// Bridge component for controlling the Unity rigidbody.
    /// </summary>
    public sealed class UnityRigidbody2D : UnityBaseEntity<Rigidbody2D>, IRigidbody2D
    {
        /// <summary>
        /// Creates a new component for controlling the Unity rigidbody.
        /// </summary>
        [FieldProxy(typeof(IRigidbody2D))]
        public UnityRigidbody2D(Rigidbody2D rigidbody2D) : base(rigidbody2D) { }

        /// <summary>
        /// Linear velocity of a physical object.
        /// </summary>
        public Vector2 LinearVelocity
        {
            get => Original.linearVelocity.ToIce();
            set => Original.linearVelocity = value.ToUnity();
        }

        /// <summary>
        /// Angular velocity of a physical object.
        /// </summary>
        public float AngularVelocity
        {
            get => Original.angularVelocity;
            set => Original.angularVelocity = value;
        }

        /// <summary>
        /// Position of a physical object.
        /// </summary>
        public Vector2 Position
        {
            get => Original.position.ToIce();
            set => Original.position = value.ToUnity();
        }

        /// <summary>
        /// Rotation of a physical object.
        /// </summary>
        public Rotor2 Rotation
        {
            get => Original.transform.rotation.ToIce();
            set => Original.SetRotation(Rotation.ToUnity());
        }

        /// <summary>
        /// Imbuing a physical object with external force.
        /// </summary>
        public void AddForce(Vector2 force, ForceMode2D forceMode) => Original.AddForce(force.ToUnity(), (UnityForceMode2D)forceMode);

        /// <summary>
        /// Imbuing a physical object with external torque.
        /// </summary>
        public void AddTorque(float torque, ForceMode2D forceMode) => Original.AddTorque(torque, (UnityForceMode2D)forceMode);

        /// <summary>
        /// Moves the physical body into position.
        /// </summary>
        public void MovePosition(Vector2 position) => Original.MovePosition(position.ToUnity());

        /// <summary>
        /// Rotates the physical body into rotation.
        /// </summary>
        public void MoveRotation(Rotor2 rotation) => Original.MoveRotation(rotation.ToUnity());
    }
}
