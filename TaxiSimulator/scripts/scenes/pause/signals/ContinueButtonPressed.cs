using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Pause.Signals {

    public partial class ContinueButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void ContinueButtonPressedEventHandler(EventSignalArgs signalArgs = null);

        protected override string EventName => SignalName.ContinueButtonPressed;
    }
}
