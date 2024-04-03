using Godot;

namespace TaxiSimulator.Scenes.MapCameraScene.View {
    public partial class MapCamera : Camera3D {
        public const string NodePath = "map_camera";

        [Export]
        private float _speed = 2;

        private Vector3 _carPosition;

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
    }
}
