namespace TaxiSimulator.Scenes.Point.Signals {
    public class SignalsProvider {
        private static PointReachedSignal pointReachedSignal = null;

        public static PointReachedSignal PointReachedSignal {
            get {
                pointReachedSignal ??= new();
                return pointReachedSignal;
            }
        }

        public static void ClearSignals() {
            pointReachedSignal?.Dispose();
            pointReachedSignal = null;
        }
    }
}
