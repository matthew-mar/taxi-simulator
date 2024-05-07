using Godot;
using TaxiSimulator.Scenes.NavigationMark.Signals;

namespace TaxiSimulator.Scenes.City.View {
    public partial class NavRegion : NavigationAgent3D {
        public const string NodePath = "CityAgent";

        public async void FindPath(Vector3 from, Vector3 to) {
            await ToSignal(GetTree(), "physics_frame");
            var map = GetNavigationMap();
            GD.Print($"Nav region map: {map.Id}");
			var path = NavigationServer3D.MapGetPath(map, from, to, true);
            GD.Print($"Nav region path: {path.Length}");
			SignalsProvider.PathFoundedSignal.Emit(new PathFoundedArgs() {
				Path = path,
			});
        }
    }
}
