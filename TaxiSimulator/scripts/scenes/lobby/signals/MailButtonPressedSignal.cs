using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class MailButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void MailButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.MailButtonPressed;
    }
}
