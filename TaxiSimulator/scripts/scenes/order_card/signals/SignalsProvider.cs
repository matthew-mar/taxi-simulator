using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderCard.Signals {
    public partial class OrderArgs : EventSignalArgs {
        public int OrderId { get; set; }
    }

    public class SignalsProvider {
        private static OrderSelectedSignal orderSelectedSignal = null;

        private static OrderTakenSignal orderTakenSignal = null;

        public static OrderSelectedSignal OrderSelectedSignal {
            get {
                orderSelectedSignal ??= new();
                return orderSelectedSignal;
            }
        }

        public static OrderTakenSignal OrderTakenSignal {
            get {
                orderTakenSignal ??= new();
                return orderTakenSignal;
            }
        }
        
        public static void ClearSignals() {
            orderSelectedSignal = null;
            orderTakenSignal = null;
        }
    }
}
