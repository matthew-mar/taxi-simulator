namespace TaxiSimulator.Scenes.Parking.Signals {
    public class SignalsProvider {
        private static CarEnteredSignal carEnteredSignal = null;

        private static CarLeftSignal carLeftSignal = null;

        private static CarStayedSignal carStayedSingal = null;

        private static RestAllowedSignal restAllowedSignal = null;

        private static PositionBlitSignal positionBlitSignal = null;

        public static CarEnteredSignal CarEnteredSignal {
            get {
                carEnteredSignal ??= new();
                return carEnteredSignal;
            }
        }

        public static CarLeftSignal CarLeftSignal {
            get {
                carLeftSignal ??= new();
                return carLeftSignal;
            }
        }

        public static CarStayedSignal CarStayedSignal {
            get {
                carStayedSingal ??= new();
                return carStayedSingal;
            }
        }

        public static RestAllowedSignal RestAllowedSignal {
            get {
                restAllowedSignal ??= new();
                return restAllowedSignal;
            }
        }

        public static PositionBlitSignal PositionBlitSignal {
            get {
                positionBlitSignal ??= new();
                return positionBlitSignal;
            }
        }

        public static void ClearSignals() {
            carEnteredSignal = null;
            carLeftSignal = null;
            carStayedSingal = null;
            restAllowedSignal = null;
            positionBlitSignal = null;
        }
    }
}
