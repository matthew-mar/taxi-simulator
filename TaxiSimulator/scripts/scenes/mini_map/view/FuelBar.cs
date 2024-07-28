using Godot;

namespace TaxiSimulator.Scenes.MiniMap.View {
    public partial class FuelBar : ProgressBar {
        public const string NodePath = "MarginContainer/MiniMapBase/FuelBase/ProgressBar";

        public void SetFuelLevel(double level) {
            Value = level;
        }
    }
}
