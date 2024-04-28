using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class ActionCPressedSignal : EventSignal {
        [Signal]
        public delegate void ActionCPressedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.ActionCPressed;
    }
}
