namespace TaxiSimulator.Scenes.GameScene.Signals {
    public class SignalsProvider {
        private static GameModeChangedSignal gameModeChangedSignal = null;

        private static GameModeSignal currentGameModeSignal = null;

        public static GameModeChangedSignal GameModeChangedSignal {
            get {
                gameModeChangedSignal ??= new();
                return gameModeChangedSignal;
            }
        }

        public static GameModeSignal CurrentGameModeSignal {
            get {
                currentGameModeSignal ??= new();
                return currentGameModeSignal;
            }
        }

        public static void ClearSignals() {
            gameModeChangedSignal = null;
            currentGameModeSignal = null;
        }
    }
}
