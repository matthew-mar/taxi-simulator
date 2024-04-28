using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class MouseLeftClickedSignal : EventSignal {
        [Signal]
        public delegate void MouseLeftClickedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.MouseLeftClicked;
    }
}
