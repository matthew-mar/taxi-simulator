using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.CarScene.Signals {
    public partial class FuelChangedArgs : EventSignalArgs {
        public double FuelLevel {  get; set; }
    }

    public partial class FuelChangedSignal : EventSignal {
        [Signal]
        public delegate void FuelChangedEventHandler(FuelChangedArgs args);

        protected override string EventName => SignalName.FuelChanged;
    }
}
