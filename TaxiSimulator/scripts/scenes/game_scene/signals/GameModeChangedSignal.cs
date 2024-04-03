using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.GameScene.Signals {
    public partial class GameModeChangedArgs : EventSignalArgs {
        public GameMode? From { get; set; }

        public GameMode To { get; set; }
    }

    public partial class GameModeChangedSignal : EventSignal {
        [Signal]
        public delegate void GameModeChangedEventHandler(GameModeChangedArgs args);

        protected override string EventName => SignalName.GameModeChanged;
    }
}
