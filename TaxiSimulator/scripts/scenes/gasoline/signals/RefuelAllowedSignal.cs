using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Gasoline.Signals {
    public partial class RefuelAllowedArgs : EventSignalArgs {
        public bool Allowed { get; set; }
    }

    public partial class RefuelAllowedSignal : EventSignal {
        [Signal]
        public delegate void RefuelAllowedEventHandler(RefuelAllowedArgs args);

        protected override string EventName => SignalName.RefuelAllowed;
    }
}
