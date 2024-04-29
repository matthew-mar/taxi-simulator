using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Parking.Signals {
    public partial class PositionBlitArgs : EventSignalArgs {
        public Rid ParkingId { get; set; }

        public Vector3 ParkingPosition { get; set; }
    }

    public partial class PositionBlitSignal : EventSignal {
        [Signal]
        public delegate void PositionBlitEventHandler(PositionBlitArgs args);

        protected override string EventName => SignalName.PositionBlit;
    }
}
