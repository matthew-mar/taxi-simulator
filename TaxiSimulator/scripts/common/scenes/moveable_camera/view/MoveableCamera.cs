using Godot;

namespace TaxiSimulator.Common.Scenes.MoveableCameraScene.View {
    public partial class MoveableCamera : Camera3D {
		public const string NodePath = "camera";

        [Export]
		private float _speed = 2;

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
    }
}
