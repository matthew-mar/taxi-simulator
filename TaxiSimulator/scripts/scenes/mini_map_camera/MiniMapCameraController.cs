using TaxiSimulator.Scenes.MiniMapCamera.View;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;

using Godot;

namespace TaxiSimulator.Scenes.MiniMapCamera {
	public partial class MiniMapCameraController : Node3D {
		private bool _checkSignals = true;

		public override void _Ready() {
			base._Ready();

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.GameModeChanged += 
				(GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Game;
				};

			var miniMapCamera = GetNode<MiniMapCam>(MiniMapCam.NodePath);
			
			CarSignals.SignalsProvider.PositionChangedSignal.PositionChanged += 
				(CarSignals.PositionSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					miniMapCamera.FollowTargetPosition(args.CurrentPosition);
				};
			
			CarSignals.SignalsProvider.RotationChangedSignal.RotationChanged +=
				(CarSignals.RotationSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					miniMapCamera.FollowTargetRotation(args.CurrentRotation);
				};
		}
	}
}
