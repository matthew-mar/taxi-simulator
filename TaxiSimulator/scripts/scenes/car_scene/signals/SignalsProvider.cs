namespace TaxiSimulator.Scenes.CarScene.Signals {
    public class SignalsProvider {
        private static PositionChangedSignal positionChangedSignal = null;

        private static RotationChangedSignal rotationChangedSignal = null;

        private static SpeedChangedSignal speedChangedSignal = null;

        private static FuelChangedSignal fuelChangedSignal = null;

        private static RespawnedSignal respawnedSignal = null;

        public static PositionChangedSignal PositionChangedSignal {
            get {
                positionChangedSignal ??= new();
                return positionChangedSignal;
            }
        }

        public static RotationChangedSignal RotationChangedSignal {
            get {
                rotationChangedSignal ??= new();
                return rotationChangedSignal;
            }
        }

        public static SpeedChangedSignal SpeedChangedSignal {
            get {
                speedChangedSignal ??= new();
                return speedChangedSignal;
            }
        }

        public static FuelChangedSignal FuelChangedSignal {
            get {
                fuelChangedSignal ??= new();
                return fuelChangedSignal;
            }
        }

        public static RespawnedSignal RespawnedSignal {
            get {
                respawnedSignal ??= new();
                return respawnedSignal;
            }
        }

        public static void ClearSignals() {
            positionChangedSignal = null;
            rotationChangedSignal = null;
            speedChangedSignal = null;
            fuelChangedSignal = null;
            respawnedSignal = null;
        }
    }
}
