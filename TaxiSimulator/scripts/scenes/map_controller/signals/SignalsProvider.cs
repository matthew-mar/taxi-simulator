namespace TaxiSimulator.Scenes.MapController.Signals {
    public class SignalsProvider {
        private static CarLocationButtonPressedSignal carLocationButtonPressedSignal = null;

        public static CarLocationButtonPressedSignal CarLocationButtonPressedSignal {
            get {
                carLocationButtonPressedSignal ??= new();
                return carLocationButtonPressedSignal;
            }
        }

        public static void ClearSignals() {
            carLocationButtonPressedSignal?.Dispose();
            carLocationButtonPressedSignal = null;
        }
    }
}
