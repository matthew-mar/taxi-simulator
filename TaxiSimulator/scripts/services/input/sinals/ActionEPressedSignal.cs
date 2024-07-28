using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class ActionEPressedSignal : EventSignal {
        [Signal]
        public delegate void ActionEPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.ActionEPressed;
    }
}
