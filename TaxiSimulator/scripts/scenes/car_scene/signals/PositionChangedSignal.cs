using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class PositionSignalArgs : EventSignalArgs {
        public Vector3 CurrentPosition { get; set; }
    }

    public partial class PositionChangedSignal : EventSignal {
        [Signal]
        public delegate void PositionChangedEventHandler(PositionSignalArgs args);

        protected override string EventName => SignalName.PositionChanged;
    }
}
