using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class CarsButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void CarsButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.CarsButtonPressed;
    }
}
