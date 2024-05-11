using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MapCameraScene.View;
using PointSignals = TaxiSimulator.Scenes.Point.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using PlayerSignals = TaxiSimulator.Services.Player.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;

using Godot;
using TaxiSimulator.Services.Game;
using TaxiSimulator.Scenes.GameScene;
using TaxiSimulator.Common.Scenes.MoveableCameraScene;

namespace TaxiSimulator.Scenes.MapCameraScene {
	public partial class MapCameraController : MoveableCameraController {
		protected override bool Active => GameService.Instance.GameMode == GameMode.Map;

		private MapCamera _mapCamera;

		public override void _Ready() {
			base._Ready();

			GD.Print("attach map camera");

			_mapCamera = (MapCamera)_camera;

			CarSignals.SignalsProvider.PositionChangedSignal.Attach(
				Callable.From((CarSignals.PositionSignalArgs args) => {
					_mapCamera.SetCarPosition(args.CurrentPosition);
				})
			);

			MapSignals.SignalsProvider.CarLocationButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Active) {
						return;
					}
					_mapCamera.MoveToCar();
				})
			);

			InputSignals.SignalsProvider.MouseLeftClickedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Active) {
						return;
					}
					_mapCamera.BlitPoint();
				})
			);

			InputSignals.SignalsProvider.ActionCPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Active) {
						return;
					}
					_mapCamera.ClearPoint();
				})
			);

			PointSignals.SignalsProvider.PointReachedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					_mapCamera.ClearPoint();
				})
			);

			PlayerSignals.SignalsProvider.WorkflowStateChangedSignal.Attach(
				Callable.From((PlayerSignals.WorkflowStateArgs args) => {
					_mapCamera.BlitPointOnPosition(args.Point);
				})
			);
		}
	}
}
