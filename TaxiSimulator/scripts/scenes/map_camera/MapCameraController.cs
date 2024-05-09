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
using System.Collections.Generic;
using TaxiSimulator.Scenes.GameScene;
using TaxiSimulator.Services.Game;

namespace TaxiSimulator.Scenes.MapCameraScene {
	public partial class MapCameraController : Node3D {
		public const string NodePath = "SubViewport/map_camera";

		private static List<GameMode> AvailableModes = new () {
			GameMode.Map,
			GameMode.OrderGrid,
		};

		private static bool CanMove => AvailableModes.Contains(GameService.Instance.GameMode);

		public GameMode CurrentGameMode { get; set; }

		private bool Available => CurrentGameMode == GameService.Instance.GameMode;
		
		private bool MapMode => CurrentGameMode == GameMode.Map;
		
		private bool OrderGridMode => CurrentGameMode == GameMode.OrderGrid;
		
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
					if (! CanMove) {
						return;
					}

					mapCamera.MoveVertical(args.VerticalAxis);
				})
			);

			InputSignals.SignalsProvider.HorizontalPressedSignal.Attach(
				Callable.From((InputSignals.HorizontalPressedArgs args) => {
					if (! CanMove) {
						return;
					}

					mapCamera.MoveHorizontal(args.HorizontalAxis);
				})
			);

			InputSignals.SignalsProvider.MouseScrolledUpSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! CanMove) {
						return;
					}

					mapCamera.ZoomIn();
				})
			);

			InputSignals.SignalsProvider.MouseScrolledDownSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! CanMove) {
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
					if (! CanMove) {
						return;
					}

					mapCamera.MoveToCar();
				})
			);

			InputSignals.SignalsProvider.MouseLeftClickedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Available) {
						return;
					}

					if (! MapMode) {
						return;
					}

					mapCamera.BlitPoint();
				})
			);

			InputSignals.SignalsProvider.ActionCPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Available) {
						return;
					}

					if (! MapMode) {
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
