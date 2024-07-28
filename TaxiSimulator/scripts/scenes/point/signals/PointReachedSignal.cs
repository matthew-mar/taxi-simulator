using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Point.Signals {
    public partial class PointReachedSignal : EventSignal {
        [Signal]
        public delegate void PointReachedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.PointReached;
    }
}
