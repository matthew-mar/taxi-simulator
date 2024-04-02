using Godot;
using TaxiSimulator.Scenes.MiniMap.View;
using TaxiSimulator.Scenes.CarScene.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.MiniMap {
	public partial class MiniMapController : Control {
		public override void _Ready() {
			base._Ready();

			var miniMapCamera = GetNode<MiniMapCamera>(MiniMapCamera.NodePath);

			var speedText = GetNode<SpeedText>(SpeedText.NodePath);

			CarSceneSignals.SignalsProvider.PositionSignal.CarStateChanged += 
				(CarStateSignalArgs args) => {
					miniMapCamera.FollowTargetPosition(args.CurrentPosition);
					miniMapCamera.FollowTargetRotation(args.CurrentRotation);
					
					speedText.SetSpeed(args.CurrentSpeed);
				};
		}
	}
}
