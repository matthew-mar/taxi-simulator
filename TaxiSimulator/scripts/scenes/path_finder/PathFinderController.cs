using TaxiSimulator.Common;
using TaxiSimulator.Scenes.PathFinder.View;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;

namespace TaxiSimulator.Scenes.PathFinder {
	public partial class PathFinderController : Node3D {
		private PathAgent _pathAgent;

		public async override void _Ready() {
			base._Ready();
			
			_pathAgent = GetNode<PathAgent>(PathAgent.NodePath);

			SetPhysicsProcess(false);
			await ToSignal(GetTree(), "physics_frame");
			SetPhysicsProcess(true);

			NavigationMarkSignals.SignalsProvider.DestinationDestroyedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					CallDeferred(nameof(Clear));
				})
			);

			NavigationMarkSignals.SignalsProvider.PathFoundedSignal.Attach(
				Callable.From((NavigationMarkSignals.PathFoundedArgs args) => {
					_pathAgent.DrawPathOnScene(args.Path, GetTree().Root);
				})
			);
		}

		private void Clear() {
			_pathAgent.ClearLines();
		}
	}
}
