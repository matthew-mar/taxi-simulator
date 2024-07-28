using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class MapButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void MapButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.MapButtonPressed;
    }
}
