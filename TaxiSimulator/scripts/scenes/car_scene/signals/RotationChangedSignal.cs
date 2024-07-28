using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class RotationSignalArgs : EventSignalArgs {
        public Vector3 CurrentRotation { get; set; }
    }

    public partial class RotationChangedSignal : EventSignal {
        [Signal]
        public delegate void RotationChangedEventHandler(RotationSignalArgs args);

        protected override string EventName => SignalName.RotationChanged;
    }
}
