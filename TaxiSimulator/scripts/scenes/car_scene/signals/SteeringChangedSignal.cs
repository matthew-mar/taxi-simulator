using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class SteeringChangedArgs : EventSignalArgs {
        public float Steering { get; set; }
    }

    public partial class SteeringChangedSignal : EventSignal {
        [Signal]
        public delegate void SteeringChangedEventHandler(SteeringChangedArgs args);

        protected override string EventName => SignalName.SteeringChanged;
    }
}
