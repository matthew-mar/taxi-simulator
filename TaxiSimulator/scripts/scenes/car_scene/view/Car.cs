using Godot;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene.View {
	
	public partial class Car : VehicleBody3D {
		public const string NodePath = "car";

		public void Turn(float horizontalAxis) {
			Steering = horizontalAxis * 0.4f;
			SignalsProvider.RotationChangedSignal.Emit(new RotationSignalArgs() {
				CurrentRotation = GlobalRotation,
			});
		}

		public void Move(float verticalAxis) {
			EngineForce = verticalAxis * 10_000f;
			SignalsProvider.PositionChangedSignal.Emit(new PositionSignalArgs() {
				CurrentPosition = GlobalPosition,
			});
			SignalsProvider.SpeedChangedSignal.Emit(new SpeedSignalArgs() {
				CurrentSpeed = LinearVelocity,
			});
		}

		public void ForceStop() {
			EngineForce = 0f;
		}
	}
}
