using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class MouseScrolledUpSignal : EventSignal {
        [Signal]
        public delegate void MouseScrolledUpEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.MouseScrolledUp;
    }
}
