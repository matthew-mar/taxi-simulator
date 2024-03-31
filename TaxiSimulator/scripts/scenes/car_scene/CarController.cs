using TaxiSimulator.Common;
using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Common.Contracts.Controllers;
using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;

using Godot;

namespace TaxiSimulator.Scenes.CarScene {
	
	public partial class CarController : Node3D, ISceneController {
		public override void _Ready() {
			base._Ready();

			Car car = GetNode<Car>("car");
			CarSceneSignals.SignalsProvider.MovingVerticalSignal.MovingVertical += car.Move;
			CarSceneSignals.SignalsProvider.MovingHorizontalSignal.MovingHorizontal += car.Turn;

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
