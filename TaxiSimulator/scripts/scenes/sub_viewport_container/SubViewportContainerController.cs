using Godot;
using TaxiSimulator.Scenes.SubViewportContainer.View;

namespace TaxiSimulator.Scenes.SubViewportContainer {
	public partial class SubViewportContainerController : Godot.SubViewportContainer {
		public override void _Ready() {
			base._Ready();

			var subViewportWrapper = GetNode<SubViewportWrapper>(SubViewportWrapper.NodePath);
			subViewportWrapper.SetSize((int)Size.X, (int)Size.Y);
		}
	}
}
