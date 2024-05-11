namespace TaxiSimulator.Services.Order.Signals {
    public class SignalsProvider {
        private static OrdersLoadedSignal ordersLoadedSignal = null;

        public static OrdersLoadedSignal OrdersLoadedSignal {
            get {
                ordersLoadedSignal ??= new();
                return ordersLoadedSignal;
            }
        }

        public static void ClearSignals() {
            ordersLoadedSignal = null;
        }
    }
}
