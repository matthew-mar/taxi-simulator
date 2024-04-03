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
            _rotationOffset ??= GlobalRotation - currentRotation;
            GlobalRotation = (Vector3)(currentRotation + _rotationOffset);
        }
    }
}
