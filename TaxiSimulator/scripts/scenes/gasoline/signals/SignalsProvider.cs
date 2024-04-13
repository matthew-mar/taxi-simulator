namespace TaxiSimulator.Scenes.Gasoline.Signals {
    public class SignalsProvider {
        private static CarEnteredSignal carEnteredSignal = null;

        private static CarLeftSignal carLeftSignal= null;

        private static CarStayedSignal carStayedSignal= null;

        private static RefuelAllowedSignal refuelAllowedSignal= null;

        public static CarEnteredSignal CarEnteredSignal {
            get {
                carEnteredSignal ??= new();
                return carEnteredSignal;
            }
        }

        public static CarLeftSignal CarLeftSignal  {
            get {
                carLeftSignal ??= new();
                return carLeftSignal;
            }
        }

        public static CarStayedSignal CarStayedSignal {
            get {
                carStayedSignal ??= new();
                return carStayedSignal;
            }
        }

        public static RefuelAllowedSignal RefuelAllowedSignal {
            get {
                refuelAllowedSignal ??= new();
                return refuelAllowedSignal;
            }
        }

        public static void ClearSignals() {
            carEnteredSignal = null;
            carLeftSignal = null;
            carStayedSignal = null;
            refuelAllowedSignal = null;
        }
    }
}
