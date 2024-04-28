using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MapCameraScene.View;
using TaxiSimulator.Scenes.MapCameraScene.Signals;

using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;

namespace TaxiSimulator.Scenes.MapCameraScene {
	public partial class MapCameraController : Node3D {
		private bool _checkSignals = true;

		public override void _Ready() {
			base._Ready();

			var mapCamera = GetNode<MapCamera>(MapCamera.NodePath);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Map;
				})
			);

			InputSignals.SignalsProvider.VerticalPressedSignal.Attach(
				Callable.From((InputSignals.VerticalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveVertical(args.VerticalAxis);
				})
			);

			InputSignals.SignalsProvider.HorizontalPressedSignal.Attach(
				Callable.From((InputSignals.HorizontalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveHorizontal(args.HorizontalAxis);
				})
			);

			InputSignals.SignalsProvider.MouseScrolledUpSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ZoomIn();
				})
			);

			InputSignals.SignalsProvider.MouseScrolledDownSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ZoomOut();
				})
			);

			CarSignals.SignalsProvider.PositionChangedSignal.Attach(
				Callable.From((CarSignals.PositionSignalArgs args) => {
					mapCamera.SetCarPosition(args.CurrentPosition);
				})
			);

			MapSignals.SignalsProvider.CarLocationButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.MoveToCar();
				})
			);

			InputSignals.SignalsProvider.MouseLeftClickedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.BlitPoint();
				})
			);

			InputSignals.SignalsProvider.ActionCPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					mapCamera.ClearPoint();
				})
			);

			NavigationMarkSignals.SignalsProvider.PointReachedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					mapCamera.ClearPoint();
				})
			);
		}
	}
}
