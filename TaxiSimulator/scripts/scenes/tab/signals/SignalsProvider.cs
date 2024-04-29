namespace TaxiSimulator.Scenes.Tab.Signals {
    public class SignalsProvider {
        private static TabClosedSignal tabClosedSignal = null;

        public static TabClosedSignal TabClosedSignal {
            get {
                tabClosedSignal ??= new();
                return tabClosedSignal;
            }
        }

        public static void ClearSignals() {
            tabClosedSignal = null;
        }
    }
}
