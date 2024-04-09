using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class ActionCPressedSignal : EventSignal {
        [Signal]
        public delegate void ActionCPressedEventHandler(EventSignalArgs args = null);

        protected override string EventName => SignalName.ActionCPressed;
    }
}
