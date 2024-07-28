using Godot;
using TaxiSimulator.Common;


namespace TaxiSimulator.Scenes.MainMenu.Signals {
    public partial class PlayButtonPressedSignal : EventSignal {
        [Signal]
        public delegate void PlayButtonPressedEventHandler(EventSignalArgs signalArgs = null);

        protected override string EventName => SignalName.PlayButtonPressed;
    }
}
