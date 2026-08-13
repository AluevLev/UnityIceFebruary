namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    /// <summary>
    /// Abstract class for the Unity game assembler part.
    /// </summary>
    public abstract class UnityBaseGameAssembler : MonoBehaviour
    {
        /// <summary>
        /// Interface that represents the functions of the game assembler poco part.
        /// </summary>
        protected IInnerAssembler InnerAssembler
        {
            set
            {
                if (_innerAssembler != null || value == null)
                    return;

                _innerAssembler = value;
                _innerAssembler.Assemble();
            }
        }
        private IInnerAssembler _innerAssembler;
        private bool _isAssembled;

        /// <summary>
        /// Start assembling the game.
        /// </summary>
        public void Assemble()
        {
            if (_isAssembled)
                return;

            _isAssembled = true;

            Assembling();
        }

        /// <summary>
        /// Assembling the game.
        /// </summary>
        protected abstract void Assembling();

        /// <summary>
        /// Disassemble the game.
        /// </summary>
        public void Disassemble()
        {
            OnDestroy();

            Destroy(gameObject);
        }
        private void OnDestroy() => InnerAssembler = null;
        private void Update() => _innerAssembler.Time.DoFrame(Time.deltaTime);
        private void FixedUpdate() => _innerAssembler.Time.DoFixedFrame();
    }
}
