using System;
using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.NavigationMark.Signals {
    public partial class DestinationDestroyedSignal : EventSignal {
        [Signal]
        public delegate void DestinationDestroyedEventHandler(EventSignalArgs args);

        protected override string EventName => SignalName.DestinationDestroyed;
    }
}
