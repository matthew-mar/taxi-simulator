using Godot;

namespace TaxiSimulator.Common.View {
    public partial class CommonText : RichTextLabel {
        public void SetText(string text) => Text = $"[center][color=#F7CA44]{text}";
    }
}
