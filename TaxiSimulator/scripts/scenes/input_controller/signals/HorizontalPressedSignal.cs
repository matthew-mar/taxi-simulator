using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class HorizontalPressedArgs : EventSignalArgs {
        public float HorizontalAxis { get; set; }
    }

    public partial class HorizontalPressedSignal : EventSignal {
        [Signal]
        public delegate void HorizontalPressedEventHandler(HorizontalPressedArgs args);

        protected override string EventName => SignalName.HorizontalPressed;
    }
}
