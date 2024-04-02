using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class CarStateSignalArgs : EventSignalArgs {
        public Vector3 CurrentPosition { get; set; }

        public Vector3 CurrentRotation { get; set; }

        public Vector3 CurrentSpeed { get; set; }
    }

    public partial class CarStateChangedSignal : EventSignal {
        [Signal]
        public delegate void CarStateChangedEventHandler(CarStateSignalArgs args);

        protected override string EventName => SignalName.CarStateChanged;
    }
}
