using Godot;
using TaxiSimulator.Scenes.NavigationMark.Signals;

namespace TaxiSimulator.Scenes.NavigationMark.View {
	public partial class MarkAgent : NavigationAgent3D {
		public const string NodePath = "MarkAgent";

		private Vector3[] _currentPath = null;

		public async void FindPath(Vector3 from, Vector3 to) {
			await ToSignal(GetTree(), "physics_frame");
			var map = GetNavigationMap();

			// /*
			// from: {"x": -1265, "y": 3, "z": 565}
			// to: {"x": -36, "y": 3, "z": -146}
			// */

			// var from_over = new Vector3(-1265f, 3f, 565f);
			// var to_over = new Vector3(-36f, 3f, -146f);

			GD.Print($"Order: {from}");
			GD.Print($"Order: {to}");

			GD.Print($"Mark agent map: {map.Id}");
			_currentPath = NavigationServer3D.MapGetPath(map, from, to, true);
			GD.Print($"Mark agent path: {_currentPath.Length}");
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
