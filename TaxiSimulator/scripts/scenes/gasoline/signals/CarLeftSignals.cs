using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Gasoline.Signals {
    public partial class CarLeftSignal : EventSignal {
        [Signal]
        public delegate void CarLeftEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.CarLeft;
    }
}
