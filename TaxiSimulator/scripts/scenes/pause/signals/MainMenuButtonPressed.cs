using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Pause.Signals {

    public partial class MainMenuButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void MainMenuButtonPressedEventHandler(EventSignalArgs signalArgs = null);

        protected override string EventName => SignalName.MainMenuButtonPressed;
    }
}
