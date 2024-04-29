using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Parking.Signals {
    public partial class CarStayedArgs : EventSignalArgs {
        public bool CarStayed { get; set; }
    }

    public partial class CarStayedSignal : EventSignal {
        [Signal]
        public delegate void CarStayedEventHandler(CarStayedArgs args);

        protected override string EventName => SignalName.CarStayed;
    }
}
