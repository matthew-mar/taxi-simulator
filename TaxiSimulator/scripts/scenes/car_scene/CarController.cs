using TaxiSimulator.Common;
using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Common.Contracts.Controllers;

using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

using Godot;

namespace TaxiSimulator.Scenes.CarScene {
	
	public partial class CarController : Node3D, ISceneController {
		private Car _car;

		private bool _checkSignals = true;

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
				};

			InputSignals.SignalsProvider.HorizontalPressedSignal.HorizontalPressed +=
				(InputSignals.HorizontalPressedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					_car.Turn(args.HorizontalAxis);
				};

			PauseSceneSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed +=
				(EventSignalArgs args) => {
					ClearSignals();
				};
		}

		public void ClearSignals() {
			CarSceneSignals.SignalsProvider.ClearSignals();
		}

		public Node GetNode() => this;
	}
}
