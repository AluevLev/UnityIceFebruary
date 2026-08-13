namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Proxy;

    using GameObject = UnityEngine.GameObject;

    /// <summary>
    /// Bridge component for controlling the Unity gameobject.
    /// </summary>
    public sealed class UnityGameObject : UnityBaseEntity<GameObject>, IGameObject
    {
        /// <summary>
        /// Сomponent that stores the position, rotation, and scale of an object.
        /// </summary>
        public ITransform Transform { get; private init; }

        /// <summary>
        /// Physical layer on which the object resides.
        /// </summary>
        public int Layer
        {
            get => Original.layer;
            set => Original.layer = value;
        }

        /// <summary>
        /// Main component that implements the object.
        /// </summary>
        public IBaseEntity MainComponent { get; set; }

        /// <summary>
        /// Creates a new component for controlling the Unity gameobject.
        /// </summary>
        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = UnityMethods.Upsert<UnityEngine.Transform, ITransform>(gameObject.transform);
        }

        /// <summary>
        /// Attempting to get the root config from an object.
        /// </summary>
        public bool TryGetRootConfig<T>(out T rootConfig) where T : class
        {
            if (!Original.TryGetComponent(out UnityInfo info))
            {
                rootConfig = null;
                return false;
            }

            rootConfig = info.ToPoco() as T;

            UnityEngine.Object.Destroy(info);

            return true;
        }
    }
}
