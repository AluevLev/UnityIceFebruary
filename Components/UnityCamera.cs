namespace UnityIceFebruary.Components
{
    using IceFebruary.Proxy;
    using IceFebruary.Render;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Camera = UnityEngine.Camera;

    /// <summary>
    /// Bridge component for controlling the Unity camera.
    /// </summary>
    public sealed class UnityCamera : UnityBaseEntity<Camera>, ICamera
    {
        /// <summary>
        /// Creates a new component for controlling the Unity camera.
        /// </summary>
        [FieldProxy(typeof(ICamera))]
        public UnityCamera(Camera camera) : base(camera) { }

        /// <summary>
        /// Translates the position on screen to the world position.
        /// </summary>
        public Vector2 ScreenToWorldPoint(Vector2 onScreenPosition) => Original.ScreenToWorldPoint(onScreenPosition.ToUnity()).ToIce();

        /// <summary>
        /// Translates the world position to the position on screen.
        /// </summary>
        public Vector2 WorldToScreenPoint(Vector2 inWorldPosition) => Original.WorldToScreenPoint(inWorldPosition.ToUnity()).ToIce();

        /// <summary>
        /// Camera size.
        /// </summary>
        public float Size
        {
            get => Original.orthographicSize;
            set => Original.orthographicSize = value;
        }
    }
}
