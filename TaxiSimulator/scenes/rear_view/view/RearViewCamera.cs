using Godot;

namespace TaxiSimulator.Scenes.RearView.View {
    public partial class RearViewCamera : Camera3D {
        public const string NodePath = "rearview_camera";

        private Vector3? _positionOffset;

        private Vector3? _rotationOffset;

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
