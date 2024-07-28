using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderGridCameraScene.Signals {
    public partial class FlagsBlitedArgs : EventSignalArgs {
        public Vector3 DeparturePos { get; set; }

        public Vector3 DestinationPos { get; set; }
    }

    public partial class FlagsBlitedSignal : EventSignal {
        [Signal]
        public delegate void FlagsBlitedEventHandler(FlagsBlitedArgs args);

        protected override string EventName => SignalName.FlagsBlited;
    }
}
