using Godot;

namespace TaxiSimulator.Scenes.MiniMapCamera.View {
    public partial class MiniMapCam : Camera3D {
        public const string NodePath = "mini_map_camera";

        private Vector3? _positionOffset = null;

        private Vector3? _rotationOffset = null;

        public void FollowTargetPosition(Vector3 currentPosition) {
            _positionOffset ??= GlobalPosition - currentPosition;
            GlobalPosition = (Vector3)(currentPosition + _positionOffset);
        }

        public void FollowTargetRotation(Vector3 currentRotation) {
            var rotation = new Vector3(GlobalRotation.X, currentRotation.Y, currentRotation.Z);
            _rotationOffset ??= GlobalRotation - rotation;
            GlobalRotation = (Vector3)(rotation + _rotationOffset);
        }
    }
}
