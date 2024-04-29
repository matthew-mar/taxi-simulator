using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Menu.Signals {
    public partial class StateChangedArgs : EventSignalArgs {
        public MenuState? FromState { get; set; }

        public MenuState ToState { get; set; }
    }

    public partial class MenuStateChangedSignal : EventSignal {
        [Signal]
        public delegate void MenuStateChangedEventHandler(StateChangedArgs args);

        protected override string EventName => SignalName.MenuStateChanged;
    }
}
