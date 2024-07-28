using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Gasoline.Signals {
    public partial class CarEnteredSignal : EventSignal {
        [Signal]
        public delegate void CarEnteredEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.CarEntered;
    }
}
