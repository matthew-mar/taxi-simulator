namespace TaxiSimulator.Scenes.MapCameraScene.Signals {
    public class SignalsProvider {
        private static PointBlitedSignal pointBlitedSignal = null;

        private static PointCleanedSignal pointCleanedSignal = null;

        public static PointBlitedSignal PointBlitedSignal {
            get {
                pointBlitedSignal ??= new();
                return pointBlitedSignal;
            }
        }

        public static PointCleanedSignal PointCleanedSignal {
            get {
                pointCleanedSignal ??= new();
                return pointCleanedSignal;
            }
        }

        public static void ClearSignals() {
            pointBlitedSignal?.Dispose();
            pointBlitedSignal = null;

            pointCleanedSignal?.Dispose();
            pointCleanedSignal = null;
        }
    }
}
