using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingForwardSignal : EventSignal {
        [Signal]
        public delegate void MovingForwardEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingForward;
    }
}
