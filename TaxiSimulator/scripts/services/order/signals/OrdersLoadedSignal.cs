using Godot;
using TaxiSimulator.Common;
using System.Collections.Generic;
using ModelOrder = DbPackage.Models.Order;

namespace TaxiSimulator.Services.Order.Signals {
    public partial class OrdersArgs : EventSignalArgs {
        public List<ModelOrder> Orders { get; set; }
    }

    public partial class OrdersLoadedSignal : EventSignal {
        [Signal]
        public delegate void OrdersLoadedEventHandler(OrdersArgs args);

        protected override string EventName => SignalName.OrdersLoaded;
    }
}
