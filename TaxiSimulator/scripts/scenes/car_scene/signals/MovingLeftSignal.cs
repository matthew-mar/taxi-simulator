using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingLeftSignal : EventSignal {
        [Signal]
        public delegate void MovingLeftEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingLeft;
    }
}
