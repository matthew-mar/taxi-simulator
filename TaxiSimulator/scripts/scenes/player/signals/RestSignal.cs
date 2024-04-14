using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Player.Signals {
    public partial class RestArgs : EventSignalArgs {
        public Vector3 RestPoint { get; set; }
    }

    public partial class RestSignal : EventSignal {
        [Signal]
        public delegate void RestEventHandler(RestArgs args);

        protected override string EventName => SignalName.Rest;
    }
}
