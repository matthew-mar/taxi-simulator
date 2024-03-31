using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class MovingVerticalSignal : EventSignal {
        [Signal]
        public delegate void MovingVerticalEventHandler(MovingAxisArgs signalArgs);

        protected override string EventName => SignalName.MovingVertical;
    }
}
