using TaxiSimulator.Common;
using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Common.Contracts.Controllers;
using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;

using Godot;

namespace TaxiSimulator.Scenes.CarScene {
	
	public partial class CarController : Node3D, ISceneController {
		private Car _car;

		public override void _Ready() {
			base._Ready();

			_car = GetNode<Car>("car");
			CarSceneSignals.SignalsProvider.MovingVerticalSignal.MovingVertical += _car.Move;
			CarSceneSignals.SignalsProvider.MovingHorizontalSignal.MovingHorizontal += _car.Turn;

			PauseSceneSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed += 
				(EventSignalArgs args) => {
					ClearSignals();
				};
		}

		public override void _Process(double delta) {
			base._Process(delta);

			_car.BlitState();
		}

		public void ClearSignals() {
			CarSceneSignals.SignalsProvider.ClearSignals();
		}

		public Node GetNode() => this;
	}
}
