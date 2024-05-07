namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public class SignalsProvider {
        private static OrderSelectedSignal orderSelectedSignal = null;

        public static OrderSelectedSignal OrderSelectedSignal {
            get {
                orderSelectedSignal ??= new();
                return orderSelectedSignal;
            }
        }

        public static void ClearSignals() {
            orderSelectedSignal = null;
        }
    }
}
