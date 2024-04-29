using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class QuitButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void QuitButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.QuitButtonPressed;
    }
}
