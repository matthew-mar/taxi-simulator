namespace TaxiSimulator.Scenes.Menu.Signals {
    public class SignalsProvider {
        private static MenuStateChangedSignal menuStateChangedSignal = null;

        public static MenuStateChangedSignal MenuStateChangedSignal {
            get {
                menuStateChangedSignal ??= new();
                return menuStateChangedSignal;
            }
        }

        public static void ClearSignals() {
            menuStateChangedSignal = null;
        }
    }
}
