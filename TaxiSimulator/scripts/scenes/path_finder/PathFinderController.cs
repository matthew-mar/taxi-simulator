using TaxiSimulator.Common;
using TaxiSimulator.Scenes.PathFinder.View;

using MapCameraSignals = TaxiSimulator.Scenes.MapCameraScene.Signals;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;

namespace TaxiSimulator.Scenes.PathFinder {
	public partial class PathFinderController : Node3D {
		public async override void _Ready() {
			base._Ready();

			SetPhysicsProcess(false);
			await ToSignal(GetTree(), "physics_frame");
			SetPhysicsProcess(true);

			var pathAgent = GetNode<PathAgent>(PathAgent.NodePath);
			
			MapCameraSignals.SignalsProvider.PointCleanedSignal.PointCleaned +=
				(EventSignalArgs args) => {
					pathAgent.ClearLines();
				};

			NavigationMarkSignals.SignalsProvider.PathFoundedSignal.PathFounded +=
				(NavigationMarkSignals.PathFoundedArgs args) => {
					pathAgent.DrawPathOnScene(args.Path, GetTree().Root);
				};
		}
	}
}
