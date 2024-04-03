using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class EscapePressedSignal : EventSignal {
        [Signal]
        public delegate void EscapePressedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.EscapePressed;
    }
}
