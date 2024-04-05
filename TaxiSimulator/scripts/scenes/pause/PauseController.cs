using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.Pause.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

using Godot;

namespace TaxiSimulator.Scenes.Pause {

	public partial class PauseController : Control, ISceneController {
		public override void _Ready() {
			base._Ready();

			InputSignals.SignalsProvider.EscapePressedSignal.EscapePressed +=
				(EventSignalArgs args) => {
					Visible = ! Visible;
					SwitchPause();
				};

			SignalsProvider.ContinueButtonPressed.ContinueButtonPressed += 
				(EventSignalArgs args) => {
					SwitchPause();
					Visible = ! Visible;
				};

			SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed += 
				(EventSignalArgs args) => {
					SwitchPause();
					Visible = ! Visible;
					SceneSwitcher.SwitchScene(ScenePathDictionary.MainMenuScenePath, this);
				};
		}

		private void SwitchPause(EventSignalArgs args = null) {
			GetTree().Paused = ! GetTree().Paused;
		}

		public void ClearSignals() {
			SignalsProvider.ClearSignals();
		}

		public Node GetNode() => this;
	}
}
