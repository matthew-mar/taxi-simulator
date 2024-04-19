using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.MainMenu.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

using Godot;

namespace TaxiSimulator.Scenes.MainMenu {

	public partial class MainMenuController : Control, ISceneController {
		public override void _Ready() {
			base._Ready();

			SignalsProvider.PlayButtonPressedSignal.PlayButtonPressed += 
				(EventSignalArgs signalArgs) => {
					SceneSwitcher.SwitchScene(ScenePathDictionary.GameScenePath, this);
				};

			SignalsProvider.ExitButtonPressedSignal.ExitButtonPressed += 
				(EventSignalArgs signalArgs) => {
					GetTree().Quit();
				};
		}

		public void ClearSignals() {
			SignalsProvider.ClearSignals();
		}

		public Node GetNewNode() => this;
	}
}
