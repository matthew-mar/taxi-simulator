using Godot;
using TaxiSimulator.Scenes.MapCameraScene.Signals;

namespace TaxiSimulator.Scenes.MapCameraScene.View {
	public partial class MapCamera : Camera3D {
		public const string NodePath = "map_camera";

		[Export]
		private float _speed = 2;

		private Vector3 _carPosition;

		[Export]
		public PackedScene packedScene;

		private CharacterBody3D _mark = null;

		public void MoveHorizontal(float horizontalAxis) {
			var velocity = Vector3.Zero;
			velocity.X -= horizontalAxis;
			velocity = velocity.Normalized() * _speed;
			Position += velocity;
		}

		public void MoveVertical(float verticalAxis) {
			var velocity = Vector3.Zero;
			velocity.Z -= verticalAxis;
			velocity = velocity.Normalized() * _speed;
			Position += velocity;
		}

		public void ZoomOut() {
			var forward = GlobalTransform.Basis.Z.Normalized();
			GlobalTransform = new(GlobalTransform.Basis, GlobalTransform.Origin + forward * 50f);
		}

		public void ZoomIn() {
			var forward = GlobalTransform.Basis.Z.Normalized();
			GlobalTransform = new(GlobalTransform.Basis, GlobalTransform.Origin + forward * -50f);
		}

		public void SetCarPosition(Vector3 carPosition) {
			_carPosition = carPosition;
		}

		public void MoveToCar() {
			Position = new Vector3(_carPosition.X, Position.Y, _carPosition.Z);
		}

		public void BlitPoint() {
			var mousePos = GetViewport().GetMousePosition();
			var from = ProjectRayOrigin(mousePos);
			var to = from + ProjectRayNormal(mousePos) * 1000;
			var space = GetWorld3D().DirectSpaceState;
			var rawQuery = new PhysicsRayQueryParameters3D
			{
				From = from,
				To = to,
				CollisionMask = 2,
			};
			var raycastResult = space.IntersectRay(rawQuery);
			if (raycastResult.Count != 0) {
				_mark?.QueueFree();
				_mark = packedScene.Instantiate<CharacterBody3D>();
				var returnPosition = (Vector3)raycastResult["position"];
				GetTree().Root.AddChild(_mark);
				_mark.GlobalPosition = returnPosition;
				SignalsProvider.PointBlitedSignal.Emit(new PointBlitedArgs() {
					PointPosition = _mark.GlobalPosition,
					TargetPoisiton = _carPosition,
				});
			}
		}

		public void ClearPoint() {
			_mark?.QueueFree();
			_mark = null;
			SignalsProvider.PointCleanedSignal.Emit();
		}
	}
}
