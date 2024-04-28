namespace TaxiSimulator.Scenes.NavigationMark.Signals {
    public class SignalsProvider {
        private static PathFoundedSignal pathFoundedSignal = null;

        private static PointReachedSignal pointReachedSignal = null;

        private static DestinationDestroyedSignal destinationDestroyedSignal = null;

        public static PathFoundedSignal PathFoundedSignal {
            get {
                pathFoundedSignal ??= new();
                return pathFoundedSignal;
            }
        }

        public static PointReachedSignal PointReachedSignal {
            get {
                pointReachedSignal ??= new();
                return pointReachedSignal;
            }
        }

        public static DestinationDestroyedSignal DestinationDestroyedSignal {
            get {
                destinationDestroyedSignal ??= new();
                return destinationDestroyedSignal;
            }
        }

        public static void ClearSignals() {
            pathFoundedSignal = null;
            pointReachedSignal = null;
        }
    }
}
