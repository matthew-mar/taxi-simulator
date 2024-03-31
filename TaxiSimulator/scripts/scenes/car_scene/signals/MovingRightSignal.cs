using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingRightSignal : EventSignal {
        [Signal]
        public delegate void MovingRightEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingRight;
    }
}
