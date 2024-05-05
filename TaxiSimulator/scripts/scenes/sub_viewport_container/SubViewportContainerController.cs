using Godot;
using TaxiSimulator.Scenes.GameScene;
using TaxiSimulator.Scenes.MapCameraScene;
using TaxiSimulator.Scenes.SubViewportContainer.View;

namespace TaxiSimulator.Scenes.SubViewportContainer {
	public partial class SubViewportContainerController : Godot.SubViewportContainer {
		[Export]
		private GameMode ViewPortMode;

		#nullable enable
		private MapCameraController? _mapController;

		public override void _Ready() {
			base._Ready();

			_mapController = GetNodeOrNull<MapCameraController>(MapCameraController.NodePath);
			if (_mapController != null) {
				_mapController.CurrentGameMode = ViewPortMode;
			}

			var subViewportWrapper = GetNode<SubViewportWrapper>(SubViewportWrapper.NodePath);
			subViewportWrapper.SetSize((int)Size.X, (int)Size.Y);
		}
	}
}
