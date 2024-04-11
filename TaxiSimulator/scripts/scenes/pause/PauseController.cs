using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.Pause.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

using Godot;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

namespace TaxiSimulator.Scenes.Pause {

	public partial class PauseController : Control, ISceneController {
		public override void _Ready() {
			base._Ready();

			var innerController = GetNode<Control>("Control");

			InputSignals.SignalsProvider.EscapePressedSignal.EscapePressed +=
				(EventSignalArgs args) => {
					innerController.Visible = ! innerController.Visible;
					SwitchPause();
				};

			SignalsProvider.ContinueButtonPressed.ContinueButtonPressed += 
				(EventSignalArgs args) => {
					SwitchPause();
					innerController.Visible = ! innerController.Visible;
				};

			SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed += 
				(EventSignalArgs args) => {
					ClearSignals();
					SwitchPause();
					innerController.Visible = ! innerController.Visible;
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
