using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MapCameraScene.View;
using TaxiSimulator.Scenes.MapCameraScene.Signals;

using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;

namespace TaxiSimulator.Scenes.MapCameraScene {
	public partial class MapCameraController : Node3D {
		private bool _checkSignals = true;

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
					mapCamera.SetCarPosition(args.CurrentPosition);
				};

			MapSignals.SignalsProvider.CarLocationButtonPressedSignal.CarLocationButtonPressed +=
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveToCar();
				};

			InputSignals.SignalsProvider.MouseLeftClickedSignal.MouseLeftClicked += 
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.BlitPoint();
				};

			InputSignals.SignalsProvider.ActionCPressedSignal.ActionCPressed +=
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ClearPoint();
				};

			NavigationMarkSignals.SignalsProvider.PointReachedSignal.PointReached +=
				(EventSignalArgs args) => {
					mapCamera.ClearPoint();
				};
			
			PauseSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed += 
				(EventSignalArgs args) => {
					mapCamera.ClearPoint();
					SignalsProvider.ClearSignals();
				};
		}
	}
}
