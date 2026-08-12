namespace UnityIceFebruary
{
    using IceFebruary;

    public abstract class UnityBaseEntity<T> : BaseEntity where T : UnityEngine.Object
    {
        public T Original { get; private init; }
        public override bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                UnityToggler.Set(Original, _enabled);
            }
        }
        public override void Destroy()
        {
            base.Destroy();

            UnityMethods.Remove(this);

            UnityEngine.Object.Destroy(Original);
        }
        protected UnityBaseEntity(T original)
        {
            Original = original;

            _enabled = UnityToggler.Get(Original);
        }
    }
}
