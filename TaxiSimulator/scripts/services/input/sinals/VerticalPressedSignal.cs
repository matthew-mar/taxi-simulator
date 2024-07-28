using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.InputService.Signlas {
    public partial class VerticalPressedArgs : EventSignalArgs {
        public float VerticalAxis { get; set; }
    }

    public partial class VerticalPressedSignal : EventSignal {
        [Signal]
        public delegate void VerticalPressedEventHandler(VerticalPressedArgs args);

        protected override string EventName => SignalName.VerticalPressed;
    }
}
