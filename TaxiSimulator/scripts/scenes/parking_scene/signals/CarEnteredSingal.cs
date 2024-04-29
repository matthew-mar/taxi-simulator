using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Parking.Signals {
    public partial class CarEnteredSignal : EventSignal {
        [Signal]
        public delegate void CarEnetredEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.CarEnetred;
    }
}
