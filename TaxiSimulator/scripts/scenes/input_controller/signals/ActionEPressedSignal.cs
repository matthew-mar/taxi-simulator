using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.InputController.Signlas {
    public partial class ActionEPressedSignal : EventSignal {
        [Signal]
        public delegate void ActionEPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.ActionEPressed;
    }
}
