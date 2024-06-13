using Godot;

namespace TaxiSimulator.Common.View {
    public partial class Follower : Node3D {
        [Export]
        private float _moveSpeed = 4f;

        private PathFollow3D _pathFollow;

        public override void _Ready() {
            base._Ready();
            _pathFollow = GetParent<PathFollow3D>();
        }

        public override void _PhysicsProcess(double delta) {
            base._PhysicsProcess(delta);
            _pathFollow.Progress += _moveSpeed * (float)delta;
        }
    }
}
