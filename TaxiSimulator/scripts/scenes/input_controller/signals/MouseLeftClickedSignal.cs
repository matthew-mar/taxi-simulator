using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class MouseLeftClickedSignal : EventSignal {
        [Signal]
        public delegate void MouseLeftClickedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.MouseLeftClicked;
    }
}
