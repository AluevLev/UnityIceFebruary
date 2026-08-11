namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Proxy;

    using GameObject = UnityEngine.GameObject;

    public sealed class UnityGameObject : UnityBaseEntity<GameObject>, IGameObject
    {
        public ITransform Transform { get; private init; }
        public int Layer
        {
            get => Original.layer;
            set => Original.layer = value;
        }
        public IBaseEntity MainComponent { get; set; }

        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = UnityMethods.Upsert<UnityEngine.Transform, ITransform>(gameObject.transform);
        }
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
