using TaxiSimulator.Common;
using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Common.Contracts.Controllers;

using PlayerSingals = TaxiSimulator.Services.Player.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Signals;
using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GasolineSignals = TaxiSimulator.Scenes.Gasoline.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;

using Godot;
using System;
using System.Collections.Generic;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene {
	public enum CameraMode {
		Back,
		Inside,
	}
	
	public partial class CarController : Node3D {
		private Car _car;

		private bool _checkSignals = true;

		private CameraMode _cameraMode = CameraMode.Back;

		private SteerWheel _steerWheel;

		public override void _Ready() {
			base._Ready();

			_car = GetNode<Car>(Car.NodePath);
			// _car.Respawn();

			_steerWheel = GetNode<SteerWheel>(SteerWheel.NodePath);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Game;
					if (! _checkSignals) {
						_car.ForceStop();
					}
				})
			);

			InputSignals.SignalsProvider.VerticalPressedSignal.Attach(
				Callable.From((InputSignals.VerticalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.Move(args.VerticalAxis);
					_car.Stop(args.VerticalAxis);
				})
			);

			InputSignals.SignalsProvider.HorizontalPressedSignal.Attach(
				Callable.From((InputSignals.HorizontalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.Turn(args.HorizontalAxis);
				})
			);

			InputSignals.SignalsProvider.ActionCPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_cameraMode = _cameraMode switch {
						CameraMode.Back => CameraMode.Inside,
						CameraMode.Inside => CameraMode.Back,
						_ => throw new ArgumentException("Illigal camera mode"),
					};
					_car.SetCamera(_cameraMode);
				})
			);

			GasolineSignals.SignalsProvider.RefuelAllowedSignal.Attach(
				Callable.From((GasolineSignals.RefuelAllowedArgs args) => {
					if (! args.Allowed) {
						return;
					}

					_car.Refuel();
				})
			);

			PlayerSingals.SignalsProvider.TiredSignal.Attach(
				Callable.From((PlayerSingals.TirednessArgs args) => {
					if (! _checkSignals) {
						return;
					}

					if (args.Tiredness >= 0f) {
						return;
					}

					if (_car.OnSpawnPosition) {
						return;
					}

					if (! _car.FullStoped) {
						return;
					}

					_car.ForceStop();
					_car.Respawn();
				})
			);

			PlayerSingals.SignalsProvider.RestSignal.Attach(
				Callable.From((PlayerSingals.RestArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.SetSpawnPosition(args.RestPoint);
				})
			);

			SignalsProvider.SteeringChangedSignal.Attach(
				Callable.From((SteeringChangedArgs args) => {
					_steerWheel.RotateWheel(args.Steering);
				})
			);
		}

		public override void _Process(double delta) {
			base._Process(delta);
			_car.SendPosition();
			_car.SendRotation();
			_car.SendSpeed();
			_car.SendFuel();
			_car.SendSteering();
		}
	}
}
