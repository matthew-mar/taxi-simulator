using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Scenes.MapCameraScene.Signals;
using TaxiSimulator.Common.Scenes.MoveableCameraScene.View;

namespace TaxiSimulator.Scenes.MapCameraScene.View {
	public partial class MapCamera : MoveableCamera {
		private Vector3 _carPosition;

		private CharacterBody3D _mark = null;
		
		public void SetCarPosition(Vector3 carPosition) => _carPosition = carPosition;

		public void MoveToCar() => Position = new(_carPosition.X, Position.Y, _carPosition.Z);

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
				var returnPosition = (Vector3)raycastResult["position"];
				BlitPointOnPosition(returnPosition);
			}
		}

		public void BlitPointOnPosition(Vector3 position) {
			_mark?.QueueFree();
			var markScene = GD.Load<PackedScene>(ScenePathDictionary.MarkScenePath);
			_mark = markScene.Instantiate<CharacterBody3D>();
			GetTree().Root.AddChild(_mark);
			_mark.GlobalPosition = position;
			SignalsProvider.PointBlitedSignal.Emit(new PointBlitedArgs() {
				PointPosition = _mark.GlobalPosition,
				TargetPoisiton = _carPosition,
			});
		}

		public void ClearPoint() {
			_mark?.QueueFree();
			_mark = null;
			SignalsProvider.PointCleanedSignal.Emit();
		}
	}
}
