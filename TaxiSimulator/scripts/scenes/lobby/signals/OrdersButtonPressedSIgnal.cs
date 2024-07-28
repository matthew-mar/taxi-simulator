using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class OrdersButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void OrdersButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.OrdersButtonPressed;
    }
}
