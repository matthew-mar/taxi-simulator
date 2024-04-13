using Godot;

namespace TaxiSimulator.Scenes.MiniMap.View {
    public partial class SuggestionText : RichTextLabel {
        public const string NodePath = "MarginContainer/MiniMapBase/Suggestion/SuggestionText";

        private const string SuggestionStyle = "[center][color=#FAEBCD]";

        public void SetText(string text) {
            Text = $"{SuggestionStyle}{text}";
        }
    }
}
