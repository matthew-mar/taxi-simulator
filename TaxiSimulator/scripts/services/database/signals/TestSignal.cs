using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Db.Signals {
    public partial class TestSignal : EventSignal {
        [Signal]
        public delegate void TestEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.Test;
    }
}
