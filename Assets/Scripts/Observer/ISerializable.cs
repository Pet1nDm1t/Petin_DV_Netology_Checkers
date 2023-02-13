using System;

namespace Checkers
{
    interface ISerializable
    {
        public event Action ObjectsMoved;

        public event Action<ColorType> GameEnded;

        public event Action<BaseClickComponent> ChipDestroyed;

        public event Action StepOver;

    }
}
