using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Parking.Signals {
    public partial class RestAllowedArgs : EventSignalArgs {
        public bool Allowed { get; set; }

        public Vector3 ParkingPosition { get; set; }
    }

    public partial class RestAllowedSignal : EventSignal {
        [Signal]
        public delegate void RestAllowedEventHandler(RestAllowedArgs args);

        protected override string EventName => SignalName.RestAllowed;
    }
}
