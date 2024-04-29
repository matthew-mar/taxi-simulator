using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class CompanyButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void CompanyButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.CompanyButtonPressed;
    }
}
