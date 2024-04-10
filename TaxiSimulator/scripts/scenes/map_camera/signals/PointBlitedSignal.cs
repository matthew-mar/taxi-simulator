using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.MapCameraScene.Signals {
    public partial class PointBlitedArgs : EventSignalArgs {
        public Vector3 PointPosition { get; set; }

        public Vector3 TargetPoisiton { get; set; }
    }

    public partial class PointBlitedSignal : EventSignal {
        [Signal]
        public delegate void PointBlitedEventHandler(PointBlitedArgs args);

        protected override string EventName => SignalName.PointBlited;
    }
}
