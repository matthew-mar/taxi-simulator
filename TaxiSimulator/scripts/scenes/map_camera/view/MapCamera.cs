using Godot;
using System.Collections.Generic;
using Suff;

namespace TaxiSimulator.Scenes.MapCameraScene.View {
	public partial class MapCamera : Camera3D {
		public const string NodePath = "map_camera";

		[Export]
		private float _speed = 2;

		private Vector3 _carPosition;

		[Export]
		public PackedScene packedScene;

		private Mark _mark = null;

		private MeshInstance3D _line = null;

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
				_mark = packedScene.Instantiate<Mark>();
				var returnPosition = (Vector3)raycastResult["position"];
				GetTree().Root.AddChild(_mark);
				_mark.GlobalPosition = returnPosition;
				_mark.agent.TargetPosition = new Vector3(_carPosition.X, _mark.GlobalPosition.Y, _carPosition.Z);
				CallDeferred("DrawPath");
			}
		}

		private async void DrawPath() {
			await ToSignal(GetTree(), "physics_frame");
			// GD.Print(_mark.agent.TargetPosition, _mark.GlobalPosition);
			var path = NavigationServer3D.MapGetPath(_mark.agent.GetNavigationMap(), _mark.GlobalPosition, _mark.agent.TargetPosition, true);
			var meshInstance = new MeshInstance3D();
			var immedMesh = new ImmediateMesh();
			var material = new OrmMaterial3D();

			meshInstance.Mesh = immedMesh;
			meshInstance.CastShadow = GeometryInstance3D.ShadowCastingSetting.Off;

			immedMesh.SurfaceBegin(Mesh.PrimitiveType.LineStrip, material);
			if (path.Length == 0) {
				GD.Print("Here");
				path = new Vector3[] {
					new Vector3(0.1f, 0.0f, 0.1f),
					new Vector3(1000.0f, 0.0f, 1000.0f),
				};
			}
			foreach (var v in path) {
				immedMesh.SurfaceAddVertex(v);
			}
			immedMesh.SurfaceEnd();

			material.ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded;
			material.AlbedoColor = Colors.Red;

			_line?.QueueFree();
			_line = meshInstance;

			GD.Print(_line == null);

			GetTree().Root.AddChild(_line);
		}
	}
}
