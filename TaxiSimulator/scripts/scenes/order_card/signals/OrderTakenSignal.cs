using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public partial class OrderTakenSignal : EventSignal {
        [Signal]
        public delegate void OrderTakenEventHandler(OrderArgs args);

        protected override string EventName => SignalName.OrderTaken;
    }
}
