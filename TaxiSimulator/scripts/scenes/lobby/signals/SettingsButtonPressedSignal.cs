using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.View {
    public partial class SettingsButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void SettingsButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.SettingsButtonPressed;
    }
}
