namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    /// <summary>
    /// An abstract class that is inherited by root config proxies.
    /// </summary>
    public abstract class UnityInfo : MonoBehaviour
    {
        /// <summary>
        /// Convert root config to poco class.
        /// </summary>
        public abstract IRootConfig ToPoco();
    }
}
