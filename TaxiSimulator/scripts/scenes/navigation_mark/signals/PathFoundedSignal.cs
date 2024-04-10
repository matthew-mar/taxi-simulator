using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.NavigationMark.Signals {
    public partial class PathFoundedArgs : EventSignalArgs {
        public Vector3[] Path { get; set; }
    }

    public partial class PathFoundedSignal : EventSignal {
        [Signal]
        public delegate void PathFoundedEventHandler(PathFoundedArgs args);

        protected override string EventName => SignalName.PathFounded;
    }
}
