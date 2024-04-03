using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MapCameraScene.View;

using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

using Godot;


namespace TaxiSimulator.Scenes.MapCameraScene {
	public partial class MapCameraController : Node3D {
		private bool _checkSignals = false;

		public override void _Ready() {
			base._Ready();

			var mapCamera = GetNode<MapCamera>(MapCamera.NodePath);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.GameModeChanged += 
				(GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Map;
				};

			InputSignals.SignalsProvider.VerticalPressedSignal.VerticalPressed += 
				(InputSignals.VerticalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveVertical(args.VerticalAxis);
				};

			InputSignals.SignalsProvider.HorizontalPressedSignal.HorizontalPressed +=
				(InputSignals.HorizontalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveHorizontal(args.HorizontalAxis);
				};

			InputSignals.SignalsProvider.MouseScrolledUpSignal.MouseScrolledUp +=
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ZoomIn();
				};

			InputSignals.SignalsProvider.MouseScrolledDownSignal.MouseScrolledDown +=
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ZoomOut();
				};

			CarSignals.SignalsProvider.PositionChangedSignal.PositionChanged += 
				(CarSignals.PositionSignalArgs args) => {
					// if (! _checkSignals) {
					// 	return;
					// }

					mapCamera.SetCarPosition(args.CurrentPosition);
				};

			MapSignals.SignalsProvider.CarLocationButtonPressedSignal.CarLocationButtonPressed +=
				(EventSignalArgs args) => {
					GD.Print("EHRKEJRWEKJREWJKR");

					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveToCar();
				};
		}
	}
}
