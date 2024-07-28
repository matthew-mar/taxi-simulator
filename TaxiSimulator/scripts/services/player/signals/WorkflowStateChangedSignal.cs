using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Player.Signals {
    public partial class WorkflowStateArgs : EventSignalArgs {
        public Vector3 Point { get; set; }
    }

    public partial class WorkflowStateChangedSignal : EventSignal {
        [Signal]
        public delegate void WorkflowStateChangedEventHandler(WorkflowStateArgs args);

        protected override string EventName => SignalName.WorkflowStateChanged;
    }
}
