using Godot;

namespace TaxiSimulator.Scenes.SubViewportContainer.View {
    public partial class SubViewportWrapper : SubViewport {
        public const string NodePath = "SubViewport";

        public void SetSize(int width, int height) {
            Size = new(width, height);
        }
    }
}
