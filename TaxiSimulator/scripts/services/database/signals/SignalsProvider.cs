namespace TaxiSimulator.Services.Db.Signals {
    public class SignalsProvider {
        private static DatabaseInitializedSignal databaseInitializedSignal = null;

        private static TestSignal testSignal = null;

        public static DatabaseInitializedSignal DatabaseInitializedSignal {
            get {
                databaseInitializedSignal ??= new();
                return databaseInitializedSignal;
            }
        }

        public static TestSignal TestSignal {
            get {
                testSignal ??= new();
                return testSignal;
            }
        }

        public static void ClearSignals() {
            databaseInitializedSignal = null;
            testSignal = null;
        }
    }
}
