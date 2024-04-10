using System;
using System.Threading.Tasks;
using Godot;
using TaxiSimulator.Scenes.NavigationMark.Signals;

namespace TaxiSimulator.Scenes.NavigationMark.View {
	public partial class MarkAgent : NavigationAgent3D {
		public const string NodePath = "MarkAgent";

		private Vector3[] _currentPath = null;

		public async void FindPath(Vector3 from, Vector3 to) {
			await ToSignal(GetTree(), "physics_frame");
			_currentPath = NavigationServer3D.MapGetPath(GetNavigationMap(), from, to, true);
			SignalsProvider.PathFoundedSignal.Emit(new PathFoundedArgs() {
				Path = _currentPath,
			});
		}

		public void CheckPointReach() {
			if (_currentPath == null) {
				return;
			}

			if (_currentPath.Length <= 2) {
				_currentPath = null;
				SignalsProvider.PointReachedSignal.Emit();
			}
		}
	}
}
