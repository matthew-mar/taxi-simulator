using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Player.Signals {
    public partial class BalanceArgs : EventSignalArgs {
        public float Balance { get; set; }
    }

    public partial class BalanceSignal : EventSignal {
        [Signal]
        public delegate void BalanceEventHandler(BalanceArgs args);

        protected override string EventName => SignalName.Balance;
    }
}
