namespace UnityIceFebruary.Components
{
    using IceFebruary.Animation;
    using IceFebruary.Proxy;
    using System;
    using System.Runtime.CompilerServices;
    using UnityIceFebruary;

    using Animator = UnityEngine.Animator;

    /// <summary>
    /// Bridge component for controlling the Unity animator.
    /// </summary>
    public sealed class UnityAnimator : UnityBaseEntity<Animator>, IAnimator
    {
        /// <summary>
        /// Creates a new component for controlling the Unity animator.
        /// </summary>
        [FieldProxy(typeof(IAnimator))]
        public UnityAnimator(Animator animator) : base(animator) { }

        /// <summary>
        /// Returns the current value of the variable by its hash.
        /// </summary>
        public T Get<T>(int hash) where T : struct
        {
            Type type = typeof(T);

            if (type == typeof(bool))
            {
                bool value = Original.GetBool(hash);
                return Unsafe.As<bool, T>(ref value);
            }

            if (type == typeof(int))
            {
                int value = Original.GetInteger(hash);
                return Unsafe.As<int, T>(ref value);
            }

            if (type == typeof(float))
            {
                float value = Original.GetFloat(hash);
                return Unsafe.As<float, T>(ref value);
            }

            return default;
        }

        /// <summary>
        /// Sets a new value for the animation parameter.
        /// </summary>
        public void Set<T>(int hash, T value) where T : struct
        {
            Type type = typeof(T);

            if (type == typeof(bool))
                Original.SetBool(hash, Unsafe.As<T, bool>(ref value));
            if (type == typeof(int))
                Original.SetInteger(hash, Unsafe.As<T, int>(ref value));
            if (type == typeof(float))
                Original.SetFloat(hash, Unsafe.As<T, float>(ref value));
        }

        /// <summary>
        /// Activates an animation trigger by its hash.
        /// </summary>
        public void ActivateTrigger(int hash) => Original.SetTrigger(hash);
    }
}
