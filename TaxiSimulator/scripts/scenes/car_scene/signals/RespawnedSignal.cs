using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class RespawnedSignal : EventSignal {
        [Signal]
        public delegate void RespawnedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.Respawned;
    }
}
