using Godot;

namespace TaxiSimulator.Scenes.MiniMap.View {
    public partial class TirednessBar : ProgressBar {
        public const string NodePath = "MarginContainer/MiniMapBase/TirednessBase/ProgressBar";

        public void SetTirednessLevel(double level) => Value = level;
    }
}
