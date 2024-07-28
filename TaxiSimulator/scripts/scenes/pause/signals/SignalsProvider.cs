namespace TaxiSimulator.Scenes.Pause.Signals {

    public class SignalsProvider {
        private static ContinueButtonPressedSignal continueButtonPressedSignal = null;

        private static MainMenuButtonPressedSignal mainMenuButtonPressedSignal = null;

        public static ContinueButtonPressedSignal ContinueButtonPressed {
            get {
                continueButtonPressedSignal ??= new();
                return continueButtonPressedSignal;
            }
        }

        public static MainMenuButtonPressedSignal MainMenuButtonPressed {
            get {
                mainMenuButtonPressedSignal ??= new();
                return mainMenuButtonPressedSignal;
            }
        }

        public static void ClearSignals() {
            continueButtonPressedSignal = null;
            mainMenuButtonPressedSignal = null;
        }
    }
}
