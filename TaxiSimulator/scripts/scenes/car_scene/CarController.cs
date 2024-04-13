using TaxiSimulator.Common;
using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Common.Contracts.Controllers;

using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GasolineSignals = TaxiSimulator.Scenes.Gasoline.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

using Godot;
using System;

namespace TaxiSimulator.Scenes.CarScene {
	public enum CameraMode {
		Back,
		Inside,
	}
	
	public partial class CarController : Node3D, ISceneController {
		private Car _car;

		private bool _checkSignals = true;

		private CameraMode _cameraMode = CameraMode.Back;

		public override void _Ready() {
			base._Ready();

			_car = GetNode<Car>(Car.NodePath);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.GameModeChanged +=
				(GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Game;
					if (! _checkSignals) {
						_car.ForceStop();
					}
				};

			InputSignals.SignalsProvider.VerticalPressedSignal.VerticalPressed +=
				(InputSignals.VerticalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.Move(args.VerticalAxis);
					_car.Stop(args.VerticalAxis);
				};

			InputSignals.SignalsProvider.HorizontalPressedSignal.HorizontalPressed +=
				(InputSignals.HorizontalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.Turn(args.HorizontalAxis);
				};

			InputSignals.SignalsProvider.ActionCPressedSignal.ActionCPressed += 
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_cameraMode = _cameraMode switch {
						CameraMode.Back => CameraMode.Inside,
						CameraMode.Inside => CameraMode.Back,
						_ => throw new ArgumentException("Illigal camera mode"),
					};
					_car.SetCamera(_cameraMode);
				};

			PauseSceneSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed +=
				(EventSignalArgs args) => {
					ClearSignals();
				};

			GasolineSignals.SignalsProvider.RefuelAllowedSignal.RefuelAllowed +=
				(GasolineSignals.RefuelAllowedArgs args) => {
					if (! args.Allowed) {
						return;
					}

					_car.Refuel();
				};
		}

		public void ClearSignals() {
			CarSceneSignals.SignalsProvider.ClearSignals();
		}

		public Node GetNode() => this;

		public override void _Process(double delta) {
			base._Process(delta);

			_car.SendPosition();
			_car.SendRotation();
			_car.SendSpeed();
			_car.SendFuel();
		}
	}
}
