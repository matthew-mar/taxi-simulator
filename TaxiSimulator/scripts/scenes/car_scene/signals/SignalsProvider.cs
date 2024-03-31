namespace TaxiSimulator.Scenes.CarScene.Signals {
    public class SignalsProvider {
        private static MovingVerticalSignal movingVerticalSignal = null;

        private static MovingHorizontalSignal movingHorizontalSignal = null;

        public static MovingVerticalSignal MovingVerticalSignal {
            get {
                movingVerticalSignal ??= new();
                return movingVerticalSignal;
            }
        }

        public static MovingHorizontalSignal MovingHorizontalSignal {
            get {
                movingHorizontalSignal ??= new();
                return movingHorizontalSignal;
            }
        }

        public static void ClearSignals() {
            movingVerticalSignal = null;
            movingHorizontalSignal = null;
        }
    }
}
