using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class MouseScrolledDownSignal : EventSignal {
        [Signal]
        public delegate void MouseScrolledDownEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.MouseScrolledDown;
    }
}
