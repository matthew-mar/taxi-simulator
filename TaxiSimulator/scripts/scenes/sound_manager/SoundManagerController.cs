using Godot;
using TaxiSimulator.Common;

using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using MainMenuSignals = TaxiSimulator.Scenes.MainMenu.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

namespace TaxiSimulator.Scenes.SoundManager {
	public partial class SoundManagerController : Node {
		private static SoundManagerController Instance = null;

		public override void _Ready() {
			base._Ready();

			Instance ??= this;

			var buttonPlayer = Instance.GetNode<AudioStreamPlayer>("ButtonPlayer");
			var motorPlayer = Instance.GetNode<AudioStreamPlayer>("MotorPlayer");
			motorPlayer.Playing = true;

			MainMenuSignals.SignalsProvider.PlayButtonPressedSignal.PlayButtonPressed +=
				(EventSignalArgs args) => {
					buttonPlayer.Play();
				};

			MainMenuSignals.SignalsProvider.ExitButtonPressedSignal.ExitButtonPressed +=
				(EventSignalArgs args) => {
					buttonPlayer.Play();
				};

			PauseSignals.SignalsProvider.ContinueButtonPressed.ContinueButtonPressed +=
				(EventSignalArgs args) => {
					buttonPlayer.Play();
				};

			PauseSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed +=
				(EventSignalArgs args) => {
					buttonPlayer.Play();
				};

			CarSignals.SignalsProvider.SpeedChangedSignal.SpeedChanged +=
				(CarSignals.SpeedSignalArgs args) => {
					var speedKm = args.CurrentSpeed.Length();
					if (speedKm > 0) {
						motorPlayer.PitchScale = 1f + speedKm / 50f;
					}
				};
		}
	}
}
