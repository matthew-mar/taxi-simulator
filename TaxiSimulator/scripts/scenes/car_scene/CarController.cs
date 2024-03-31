using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Scenes.CarScene.Signals;

using Godot;

namespace TaxiSimulator.Scenes.CarScene {
	
	public partial class CarController : Node3D {
		public override void _Ready() {
			base._Ready();

			Car car = GetNode<Car>("car");
			SignalsProvider.MovingForwardSignal.MovingForward += car.Move;
			SignalsProvider.MovingLeftSignal.MovingLeft += car.Turn;
		}
	}
}
