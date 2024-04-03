namespace TaxiSimulator.Scenes.GameScene.Signals {
    public class SignalsProvider {
        private static GameModeChangedSignal gameModeChangedSignal = null;

        public static GameModeChangedSignal GameModeChangedSignal {
            get {
                gameModeChangedSignal ??= new();
                return gameModeChangedSignal;
            }
        }

        public static void ClearSignals() {
            gameModeChangedSignal = null;
        }
    }
}
