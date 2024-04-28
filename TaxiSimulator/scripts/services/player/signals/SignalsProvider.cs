namespace TaxiSimulator.Services.Player.Signals {
    public class SignalsProvider {
        private static TirednessSignal tiredSignal = null;

        private static RestSignal restSignal = null;

        public static TirednessSignal TiredSignal {
            get {
                tiredSignal ??= new();
                return tiredSignal;
            }
        }

        public static RestSignal RestSignal {
            get {
                restSignal ??= new();
                return restSignal;
            }
        }

        public static void ClearSingals() {
            tiredSignal = null;
            restSignal = null;
        }
    }
}
