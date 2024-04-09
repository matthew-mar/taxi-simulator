using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.CarScene.View {
	
	public partial class Car : VehicleBody3D {
		public const string NodePath = "car";

		private NavigationAgent3D _agent;

		private TestCamera _camera;

		private MeshInstance3D _line = null;

		public async override void _Ready() {
			base._Ready();

			_agent = GetNode<NavigationAgent3D>("NavigationAgent3D");
			// _camera = GetParent().GetNode<TestCamera>("Camera3D");

			SetPhysicsProcess(false);
			await ToSignal(GetTree(), "physics_frame");
			SetPhysicsProcess(true);

			// CallDeferred("CustomSetup");
		}

		public override void _Input(InputEvent @event) {
			base._Input(@event);

			// if (@event.IsActionPressed(InputActionDictionary.LeftClick)) {
			// 	_agent.TargetPosition = _camera.TargetPoint;
			// 	// CallDeferred("CustomSetup");
			// }
		}

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

		private async void CustomSetup() {
			await ToSignal(GetTree(), "physics_frame");
			var path = NavigationServer3D.MapGetPath(
				_agent.GetNavigationMap(),
				GlobalPosition,
				_agent.TargetPosition,
				true
			);
			GD.Print("Only here i am onlu here ", path, path.Length);
			var meshInstance = new MeshInstance3D();
			var immedMesh = new ImmediateMesh();
			var material = new OrmMaterial3D();

			meshInstance.Mesh = immedMesh;
			meshInstance.CastShadow = GeometryInstance3D.ShadowCastingSetting.Off;

			immedMesh.SurfaceBegin(Mesh.PrimitiveType.LineStrip, material);
			foreach (var v in path) {
				immedMesh.SurfaceAddVertex(v);
			}
			immedMesh.SurfaceEnd();

			material.ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded;
			material.AlbedoColor = Colors.Red;

			_line?.QueueFree();
			_line = meshInstance;
			GetTree().Root.AddChild(_line);
		}
	}
}
