using Godot;

namespace TaxiSimulator.Scenes.MiniMap.View {
    public partial class MiniMapCamera : Camera3D {
        public const string NodePath = "MarginContainer/MiniMapBase/MarginContainer/SubViewportContainer/SubViewport/Camera3D";

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
