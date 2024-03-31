using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingHorizontalSignal : EventSignal {
        [Signal]
        public delegate void MovingHorizontalEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingHorizontal;
    }
}
