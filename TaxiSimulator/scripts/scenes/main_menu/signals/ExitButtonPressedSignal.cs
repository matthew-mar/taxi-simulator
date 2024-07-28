using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.MainMenu.Signals {
    public partial class ExitButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void ExitButtonPressedEventHandler(EventSignalArgs signalArgs = null);

        protected override string EventName => SignalName.ExitButtonPressed;
    }
}
