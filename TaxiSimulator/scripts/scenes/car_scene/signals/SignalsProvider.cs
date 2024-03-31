namespace TaxiSimulator.Scenes.CarScene.Signals {
    
    public class SignalsProvider {
        private static MovingBackwardSignal movingBackwardSignal = null;
        
        private static MovingForwardSignal movingForwardSignal = null;

        private static MovingLeftSignal movingLeftSignal = null;

        private static MovingRightSignal movingRightSignal = null;

        public static MovingBackwardSignal MovingBackwardSignal {
            get {
                movingBackwardSignal ??= new();
                return movingBackwardSignal;
            }
        }

        public static MovingForwardSignal MovingForwardSignal {
            get {
                movingForwardSignal ??= new();
                return movingForwardSignal;
            }
        }

        public static MovingLeftSignal MovingLeftSignal {
            get {
                movingLeftSignal ??= new();
                return movingLeftSignal;
            }
        }

        public static MovingRightSignal MovingRightSignal {
            get {
                movingRightSignal ??= new();
                return movingRightSignal;
            }
        }
    }
}
