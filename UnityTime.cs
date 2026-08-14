namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Collections;
    using IceFebruary.Time;
    using UnityEngine;

    /// <summary>
    /// Untiy realization of the core time management interface.
    /// Controls execution of regular and fixed update frames.
    /// </summary>
    public sealed class UnityTime : BaseEntity, ITime
    {
        private readonly EntityFastArray<IFrame> _frameArray;
        private readonly EntityFastArray<IFixedFrame> _fixedFrameArray;

        /// <summary>
        /// Creates a new untiy realization of the core time management interface.
        /// Controls execution of regular and fixed update frames.
        /// </summary>
        public UnityTime(int startArraySize)
        {
            _frameArray = new(startArraySize);
            _fixedFrameArray = new(startArraySize);
        }

        /// <summary>
        /// Total elapsed game time in seconds since system startup.
        /// </summary>
        public float CurrentTime => Time.time;

        /// <summary>
        /// Fixed time step duration specifically for fixed updates.
        /// </summary>
        public float FixedFrameRate
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }

        /// <summary>
        /// Registers and launches a frame update listener.
        /// </summary>
        public void LaunchIFrame(IFrame frame)
        {
            if (frame.Exists())
                _frameArray.Register(frame);
        }

        /// <summary>
        /// Registers and launches a fixed frame update listener.
        /// </summary>
        public void LaunchIFixedFrame(IFixedFrame fixedFrame)
        {
            if (fixedFrame.Exists())
                _fixedFrameArray.Register(fixedFrame);
        }

        /// <summary>
        /// Processes a single regular frame iteration.
        /// </summary>
        public void DoFrame(float frameLength)
        {
            for (int index = 0; index < _frameArray.Length; index++)
            {
                IFrame frame = _frameArray.Entities[index];

                if (frame.Exists())
                    frame.OnFrame(frameLength);
            }
        }

        /// <summary>
        /// Processes a single fixed frame tick step.
        /// </summary>
        public void DoFixedFrame()
        {
            for (int index = 0; index < _fixedFrameArray.Length; index++)
            {
                IFixedFrame fixedFrame = _fixedFrameArray.Entities[index];

                if (fixedFrame.Exists())
                    fixedFrame.OnFixedFrame();
            }
        }
    }
}
