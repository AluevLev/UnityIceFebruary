namespace UnityIceFebruary
{
    using IceFebruary;

    /// <summary>
    /// Abstract class for bridge components.
    /// </summary>
    public abstract class UnityBaseEntity<T> : BaseEntity where T : UnityEngine.Object
    {
        /// <summary>
        /// Reference to the original Unity object that this bridge component wraps.
        /// </summary>
        public T Original { get; private init; }

        /// <summary>
        /// True, if the Unity object is enabled.
        /// </summary>
        public override bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                UnityToggler.Set(Original, _enabled);
            }
        }

        /// <summary>
        /// Destroying an Unity object.
        /// Don't use destroyed entities.
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();

            UnityMethods.Remove(this);

            UnityEngine.Object.Destroy(Original);
        }

        /// <summary>
        /// Creates a new bridge component.
        /// </summary>
        protected UnityBaseEntity(T original)
        {
            Original = original;

            _enabled = UnityToggler.Get(Original);
        }
    }
}
