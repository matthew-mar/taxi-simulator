using Godot;
using TaxiSimulator.Scenes.NavigationMark.Signals;

namespace TaxiSimulator.Scenes.City.View {
    public partial class NavRegion : NavigationAgent3D {
        public const string NodePath = "CityAgent";

        public async void FindPath(Vector3 from, Vector3 to) {
            await ToSignal(GetTree(), "physics_frame");
			var path = NavigationServer3D.MapGetPath(GetNavigationMap(), from, to, true);
			SignalsProvider.PathFoundedSignal.Emit(new PathFoundedArgs() {
				Path = path,
			});
        }
    }
}
