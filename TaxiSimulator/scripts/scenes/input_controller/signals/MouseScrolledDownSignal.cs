using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class MouseScrolledDownSignal : EventSignal {
        [Signal]
        public delegate void MouseScrolledDownEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.MouseScrolledDown;
    }
}
