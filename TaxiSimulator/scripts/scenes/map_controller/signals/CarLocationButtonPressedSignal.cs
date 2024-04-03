using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.MapController.Signals {
    public partial class CarLocationButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void CarLocationButtonPressedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.CarLocationButtonPressed;
    }
}
