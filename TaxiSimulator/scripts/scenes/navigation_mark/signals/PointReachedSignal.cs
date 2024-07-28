using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.NavigationMark.Signals {
    public partial class PointReachedSignal : EventSignal {
        [Signal]
        public delegate void PointReachedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.PointReached;
    }
}
