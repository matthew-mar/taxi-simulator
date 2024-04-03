using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class SpeedSignalArgs : EventSignalArgs {
        public Vector3 CurrentSpeed { get; set; }
    }

    public partial class SpeedChangedSignal : EventSignal {
        [Signal]
        public delegate void SpeedChangedEventHandler(SpeedSignalArgs args);

        protected override string EventName => SignalName.SpeedChanged;
    }
}
