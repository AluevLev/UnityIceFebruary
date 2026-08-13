namespace UnityIceFebruary
{
    using UnityEngine;

    /// <summary>
    /// Static class for manipulating activity objects in Unity.
    /// </summary>
    public static class UnityToggler
    {
        /// <summary>
        /// Assigns activity to a Unity object.
        /// </summary>
        public static void Set(Object target, bool value)
        {
            switch (target)
            {
                case GameObject go:
                    go.SetActive(value);
                    break;
                case Rigidbody2D rb2d:
                    rb2d.simulated = value;
                    break;
                case Rigidbody rb3d:
                    rb3d.isKinematic = !value;
                    rb3d.detectCollisions = value;
                    break;
                case Behaviour b:
                    b.enabled = value; break;
                case Renderer r:
                    r.enabled = value; break;
                case Collider c:
                    c.enabled = value; break;
                case ParticleSystem ps:
                    ParticleSystem.EmissionModule emission = ps.emission;
                    emission.enabled = value;
                    break;
            }
        }

        /// <summary>
        /// Returns the activity to the Unity object.
        /// </summary>
        public static bool Get(Object target) => target switch
        {
            GameObject go => go.activeSelf,
            Rigidbody2D rb2d => rb2d.simulated,
            Rigidbody rb3d => !rb3d.isKinematic,
            Behaviour b => b.enabled,
            Renderer r => r.enabled,
            Collider c => c.enabled,
            ParticleSystem ps => ps.emission.enabled,
            _ => true
        };
    }
}
