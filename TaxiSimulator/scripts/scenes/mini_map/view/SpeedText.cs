using Godot;

namespace TaxiSimulator.Scenes.MiniMap.View {
    public partial class SpeedText : RichTextLabel {
        public const string NodePath = "MarginContainer/MiniMapBase/SpeedBase/SpeedText";

        public void SetSpeed(Vector3 speed) {
            var speedKm = speed.Length();
            Text = $"{speedKm:f1} км/ч";
        }
    }
}
