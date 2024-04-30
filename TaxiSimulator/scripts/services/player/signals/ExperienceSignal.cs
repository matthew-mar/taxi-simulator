using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Player.Signals {
    public partial class ExperienceArgs : EventSignalArgs {
        public float Experience { get; set; }
    }

    public partial class ExperienceSignal : EventSignal {
        [Signal]
        public delegate void ExperienceEventHandler(ExperienceArgs args);

        protected override string EventName => SignalName.Experience;
    }
}
