using DbPackage.Models;
using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public partial class SelectedArgs : OrderArgs {
        public int TreeIndex { get; set; }
    }

    public partial class OrderSelectedSignal : EventSignal {
        [Signal]
        public delegate void OrderSelectedEventHandler(SelectedArgs args);

        protected override string EventName => SignalName.OrderSelected;
    }
}
