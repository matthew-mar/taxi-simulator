using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Lobby.Signals {
    public partial class DriveButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void DriveButtonPressedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.DriveButtonPressed;
    }
}
