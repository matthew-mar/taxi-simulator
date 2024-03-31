using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.Pause.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

using Godot;

namespace TaxiSimulator.Scenes.Pause {

	public partial class PauseController : Control, ISceneController {
		public override void _Ready() {
			base._Ready();

			SignalsProvider.ContinueButtonPressed.ContinueButtonPressed += SwitchPause;

			SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed += 
				(EventSignalArgs args) => {
					SwitchPause();
					SceneSwitcher.SwitchScene(ScenePathDictionary.MainMenuScenePath, this);
				};
		}

		private void SwitchPause(EventSignalArgs args = null) {
			GetTree().Paused = ! GetTree().Paused;
			Visible = ! Visible;
		}

		public void ClearSignals() {
			SignalsProvider.ClearSignals();
		}

		public Node GetNode() => this;
	}
}
