using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.View.Buttons {
    public partial class SettingsButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void SettingsButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.SettingsButtonPressed;
    }
}
