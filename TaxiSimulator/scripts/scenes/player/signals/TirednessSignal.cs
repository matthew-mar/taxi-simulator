using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Player.Signals {
    public partial class TirednessArgs : EventSignalArgs {
        public double Tiredness { get; set; }
    }

    public partial class TirednessSignal : EventSignal {
        [Signal]
        public delegate void TirednessEventHandler(TirednessArgs args);

        protected override string EventName => SignalName.Tiredness;
    }
}
