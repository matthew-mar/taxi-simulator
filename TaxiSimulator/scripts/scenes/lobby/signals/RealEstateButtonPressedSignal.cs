using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class RealEstateButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void RealEstateButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.RealEstateButtonPressed;
    }
}
