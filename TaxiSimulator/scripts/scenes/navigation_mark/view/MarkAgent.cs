using Godot;
using TaxiSimulator.Scenes.NavigationMark.Signals;

namespace TaxiSimulator.Scenes.NavigationMark.View {
	public partial class MarkAgent : NavigationAgent3D {
		public const string NodePath = "MarkAgent";

		private Vector3[] _currentPath = null;

		private int pathChangedCount = 0;

        public override void _Ready() {
            base._Ready();
			PathChanged += () => {
				FindPath(this.GetParent<Sprite3D>().GlobalPosition, TargetPosition);
			};
        }

		public void SetTarget(Vector3 target) {
			TargetPosition = target;
		}

        public async void FindPath(Vector3 from, Vector3 to) {
			await ToSignal(GetTree(), "physics_frame");
			_currentPath = NavigationServer3D.MapGetPath(GetNavigationMap(), from, to, false);
			SignalsProvider.PathFoundedSignal.Emit(new PathFoundedArgs() {
				Path = _currentPath,
			});
		}

        public override void _PhysicsProcess(double delta) {
            GetNextPathPosition();
        }

        public void CheckPointReach() {
			if (_currentPath == null) {
				return;
			}

			if (_currentPath.Length <= 1) {
				_currentPath = null;
				SignalsProvider.PointReachedSignal.Emit();
			}
		}
	}
}
