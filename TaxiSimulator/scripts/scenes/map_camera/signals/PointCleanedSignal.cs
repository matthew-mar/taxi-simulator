using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.MapCameraScene.Signals {
    public partial class PointCleanedSignal : EventSignal {
        [Signal]
        public delegate void PointCleanedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.PointCleaned;
    }
}
