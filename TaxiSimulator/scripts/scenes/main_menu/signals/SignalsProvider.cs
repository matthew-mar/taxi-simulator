namespace TaxiSimulator.Scenes.MainMenu.Signals {
    public class SignalsProvider {
        private static PlayButtonPressedSignal playButtonPressedSignal = null;

        private static ExitButtonPressedSignal exitButtonPressedSignal = null;

        public static PlayButtonPressedSignal PlayButtonPressedSignal {
            get {
                playButtonPressedSignal ??= new();
                return playButtonPressedSignal;
            }
        }

        public static ExitButtonPressedSignal ExitButtonPressedSignal {
            get {
                exitButtonPressedSignal ??= new();
                return exitButtonPressedSignal;
            }
        }

        public static void ClearSignals() {
            playButtonPressedSignal = null;
            exitButtonPressedSignal = null;
        }
    }
}
