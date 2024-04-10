using Godot;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene.View {
	
	public partial class Car : VehicleBody3D {
		public const string NodePath = "car";

		private Camera3D _backCamera;

		private Camera3D _insideCamera;

		public override void _Ready() {
			_backCamera = GetNode<Camera3D>("BackCamera");
			_insideCamera = GetNode<Camera3D>("InsideCamera");
		}

		public void Turn(float horizontalAxis) {
			Steering = horizontalAxis * 0.4f;
		}

		public void Move(float verticalAxis) {
			EngineForce = verticalAxis * 10_000f;
		}

		public void ForceStop() {
			EngineForce = 0f;
		}

		public void SendPosition() {
			SignalsProvider.PositionChangedSignal.Emit(new PositionSignalArgs() {
				CurrentPosition = GlobalPosition,
			});
		}

		public void SendRotation() {
			SignalsProvider.RotationChangedSignal.Emit(new RotationSignalArgs {
				CurrentRotation = GlobalRotation,
			});
		}

		public void SendSpeed() {
			SignalsProvider.SpeedChangedSignal.Emit(new SpeedSignalArgs {
				CurrentSpeed = LinearVelocity,
			});
		}

		public void SetCamera(CameraMode cameraMode) {
			switch (cameraMode) {
				case CameraMode.Back:
					_backCamera.Current = true;
					break;

				case CameraMode.Inside:
					_insideCamera.Current = true;
					break;
			}
		}
	}
}
