namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    /// <summary>
    /// Unity realization of an interface that acts as a manager for creating game objects.
    /// </summary>
    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        /// <summary>
        /// Creates a new Unity realization of an interface that acts as a manager for creating game objects.
        /// </summary>
        public UnityObjectManager() { }

        /// <summary>
        /// Create a game object on scene.
        /// </summary>
        public IGameObject Create(IGameObject gameObject, Vector2 position, Rotor2 rotation) => gameObject is UnityGameObject unityGameObject ? UnityMethods.Upsert<UnityEngine.GameObject, IGameObject>(UnityEngine.Object.Instantiate(unityGameObject.Original, position.ToUnity(), rotation.ToUnity())) : null;
    }
}
