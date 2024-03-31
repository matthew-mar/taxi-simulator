using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingBackwardSignal : EventSignal {
        [Signal]
        public delegate void MovingBackwardEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingBackward;
    }
}
