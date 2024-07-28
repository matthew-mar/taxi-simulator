namespace TaxiSimulator.Scenes.OrderGridCameraScene.Signals {
    public class SignalsProvider {
        private static FlagsBlitedSignal flagsBlitedSignal = null;

        public static FlagsBlitedSignal FlagsBlitedSignal {
            get {
                flagsBlitedSignal ??= new();
                return flagsBlitedSignal;
            }
        }

        public static void ClearSignals() {
            flagsBlitedSignal?.Dispose();
            flagsBlitedSignal = null;
        }
    }
}
