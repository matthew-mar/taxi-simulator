using TaxiSimulator.Scenes.MiniMap.View;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;

using Godot;

namespace TaxiSimulator.Scenes.MiniMap {
	public partial class MiniMapController : Control {
		private bool _checkSignals = true;

		public override void _Ready() {
			base._Ready();

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.GameModeChanged += 
				(GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Game;
				};

			var speedText = GetNode<SpeedText>(SpeedText.NodePath);

			CarSceneSignals.SignalsProvider.SpeedChangedSignal.SpeedChanged +=
				(CarSceneSignals.SpeedSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					speedText.SetSpeed(args.CurrentSpeed);
				};
		}
	}
}
