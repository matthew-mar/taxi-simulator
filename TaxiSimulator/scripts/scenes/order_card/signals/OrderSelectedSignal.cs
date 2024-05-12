using DbPackage.Models;
using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public partial class OrderSelectedSignal : EventSignal {
        [Signal]
        public delegate void OrderSelectedEventHandler(OrderArgs args);

        protected override string EventName => SignalName.OrderSelected;
    }
}
