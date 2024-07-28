using TaxiSimulator.Common;
using TaxiSimulator.Scenes.GameScene;

using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using MainMenuSignals = TaxiSimulator.Scenes.MainMenu.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;

using Godot;

namespace TaxiSimulator.Services.Sound {
	public partial class SoundService : Node {
		public static SoundService Instance { get; private set; }

		private GameMode? _gameMode;

		public override void _Ready() {
			base._Ready();

			Instance ??= this;

			var buttonPlayer = Instance.GetNode<AudioStreamPlayer>("ButtonPlayer");
			var motorPlayer = Instance.GetNode<AudioStreamPlayer>("MotorPlayer");

			MainMenuSignals.SignalsProvider.PlayButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					buttonPlayer.Play();
				})
			);

			MainMenuSignals.SignalsProvider.ExitButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					buttonPlayer.Play();
				})
			);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					motorPlayer.Playing = args.To == GameMode.Game;
				})
			);

			CarSignals.SignalsProvider.SpeedChangedSignal.Attach(
				Callable.From((CarSignals.SpeedSignalArgs args) => {
					var speedKm = args.CurrentSpeed.Length();
					if (speedKm > 0) {
						motorPlayer.PitchScale = 1f + speedKm / 50f;
					}
				})
			);
		}
	}
}
