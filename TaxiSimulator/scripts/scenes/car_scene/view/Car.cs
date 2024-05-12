using Godot;
using TaxiSimulator.Services.Player;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene.View {
	
	public partial class Car : VehicleBody3D {
		public const string NodePath = "car_copy_1";

		public const float FullFuel = 1f;

		private const float Speed = 2_500f;

		[Export]
		private double _fuel = 1f;

		[Export]
		private float _fuelConsumption = 8.2f;

		private Camera3D _backCamera;

		private Camera3D _insideCamera;

		public float SpeedMs => LinearVelocity.Length();

		private bool CarStoped => SpeedMs <= 3f;

		public bool FullStoped => (int)SpeedMs == 0;

		public bool FullTank => _fuel == FullFuel;

		public bool OnSpawnPosition => GlobalPosition == _spawnPosition;

		private Vector3 _spawnPosition = new(-72, 4, 40);

		private float _steeringAngle = 0f;

		private double FuelConsumption {
			get {
				var fuelConsumptionPerKm = _fuelConsumption / 100f;
				var fuelConsumptionPerM = fuelConsumptionPerKm / 1000f;
				var fuelConsumptionPerS = SpeedMs * fuelConsumptionPerM;
				var framesCount = Engine.GetFramesPerSecond();
				var fuelConsumptionPerFrame = fuelConsumptionPerS / framesCount;
				return fuelConsumptionPerFrame;
			}
		}

		public override void _Ready() {
			_backCamera = GetNode<Camera3D>("BackCamera");
			_insideCamera = GetNode<Camera3D>("InsideCamera");
		}

		public void Turn(float horizontalAxis) {
			if (PlayerService.Instance.Tired) {
				Steering = 0f;
				return;
			}

			if (Mathf.Abs(horizontalAxis) > 0) {
				_steeringAngle = Mathf.Clamp(_steeringAngle + 1f * horizontalAxis * 0.4f, -45f, 45f);
			} else if (_steeringAngle > 0) {
				_steeringAngle -= 0.4f;
				if (_steeringAngle < 0) {
					_steeringAngle = 0f;
				}
			} else if (_steeringAngle < 0) {
				_steeringAngle += 0.4f;
				if (_steeringAngle > 0) {
					_steeringAngle = 0f;
				}
			}
			var radians = _steeringAngle * (Mathf.Pi / 180);
			Steering = radians;
		}

		public void Move(float verticalAxis) {
			if (PlayerService.Instance.Tired) {
				EngineForce = 0;
				return;
			}

			if (_fuel <= 0) {
				EngineForce = 0;
				if (! CarStoped) {
					if (verticalAxis < 0) {
						EngineForce = verticalAxis * Speed;			
					}
				} else {
					EngineForce = 0;
				}
			} else {
				EngineForce = verticalAxis * Speed;
				_fuel -= FuelConsumption;
			}
		}

		public void Stop(float verticalAxis) {

		}

		public void ForceStop() {
			EngineForce = 0f;
			LinearVelocity = Vector3.Zero;
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

		public void SendFuel() {
			SignalsProvider.FuelChangedSignal.Emit(new FuelChangedArgs {
				FuelLevel = _fuel,
			});
		}

		public void SendSteering() {
			SignalsProvider.SteeringChangedSignal.Emit(new SteeringChangedArgs() {
				Steering = Steering,
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

		public void Refuel() {
			if (FullTank) {
				return;
			}

			_fuel = FullFuel;
		}

		public void Respawn() {
			GlobalPosition = _spawnPosition;
			SignalsProvider.RespawnedSignal.Emit();
		}

		public void SetSpawnPosition(Vector3 spawnPosition) {
			_spawnPosition = new Vector3(spawnPosition.X, 4, spawnPosition.Y);
		}	
	}
}
