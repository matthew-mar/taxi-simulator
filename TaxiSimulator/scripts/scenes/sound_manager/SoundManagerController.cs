using Godot;
using TaxiSimulator.Common;

using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using MainMenuSignals = TaxiSimulator.Scenes.MainMenu.Signals;

namespace TaxiSimulator.Scenes.SoundManager {
	public partial class SoundManagerController : Node {
		private static SoundManagerController Instance = null;

		public override void _Ready() {
			base._Ready();

			Instance ??= this;

			var buttonPlayer = Instance.GetNode<AudioStreamPlayer>("ButtonPlayer");

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
		}
	}
}
