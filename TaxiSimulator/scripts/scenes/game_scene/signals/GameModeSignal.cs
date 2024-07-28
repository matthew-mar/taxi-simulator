using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.GameScene.Signals {
    public partial class CurrentGameModeArgs : EventSignalArgs {
        public GameMode CurrentGameMode { get; set; }
    }

    public partial class GameModeSignal : EventSignal {
        [Signal]
        public delegate void CurrentGameModeEventHandler(CurrentGameModeArgs args);

        protected override string EventName => SignalName.CurrentGameMode;
    }
}
