using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Db.Signals {
    public partial class DatabaseInitializedSignal : EventSignal {
        [Signal]
        public delegate void DatabaseInitializedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.DatabaseInitialized;
    }
}
