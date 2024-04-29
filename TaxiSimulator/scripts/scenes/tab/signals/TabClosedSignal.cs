using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Tab.Signals {
    public partial class TabClosedSignal : EventSignal {
        [Signal]
        public delegate void TabClosedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.TabClosed;
    }
}
