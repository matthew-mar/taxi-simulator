using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class ActionMPressedSignal : EventSignal {
        [Signal]
        public delegate void ActionMPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.ActionMPressed;
    }
}
