using Godot;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene.View {
	
	public partial class Car : VehicleBody3D {
		public void Turn(MovingAxisArgs movingArgs) {
			Steering = movingArgs.MovingAxis * 0.4f;
		}

		public void Move(MovingAxisArgs movingArgs) {
			EngineForce = movingArgs.MovingAxis * 10_000f;
		}

		public void BlitState() {
			SignalsProvider.PositionSignal.Emit(new CarStateSignalArgs() {
				CurrentPosition = GlobalPosition,
				CurrentRotation = GlobalRotation,
				CurrentSpeed = LinearVelocity,
			});
		}
	}
}
