namespace TaxiSimulator.Services.Player.Signals {
    public class SignalsProvider {
        private static TirednessSignal tiredSignal = null;

        private static RestSignal restSignal = null;

        private static ExperienceSignal experienceSignal = null;

        private static BalanceSignal balanceSignal = null;

        private static WorkflowStateChangedSignal workflowStateChangedSignal = null;

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

        public static ExperienceSignal ExperienceSignal {
            get {
                experienceSignal ??= new();
                return experienceSignal;
            }
        }

        public static BalanceSignal BalanceSignal {
            get {
                balanceSignal ??= new();
                return balanceSignal;
            }
        }

        public static WorkflowStateChangedSignal WorkflowStateChangedSignal {
            get {
                workflowStateChangedSignal ??= new();
                return workflowStateChangedSignal;
            }
        }

        public static void ClearSingals() {
            tiredSignal = null;
            restSignal = null;
            experienceSignal = null;
            balanceSignal = null;
            workflowStateChangedSignal = null;
        }
    }
}
