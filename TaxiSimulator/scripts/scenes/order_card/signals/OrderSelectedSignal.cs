using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public partial class OrderSelectedArgs : EventSignalArgs {
        public int OrderId { get; set; }
    }

    public partial class OrderSelectedSignal : EventSignal {
        [Signal]
        public delegate void OrderSelectedEventHandler(OrderSelectedArgs args);

        protected override string EventName => SignalName.OrderSelected;
    }
}
