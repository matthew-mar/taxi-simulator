using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MainMenu.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;

using Godot;

namespace TaxiSimulator.Scenes.MainMenu {

	public partial class MainMenuController : Control {
		public override void _Ready() {
			base._Ready();

			SignalsProvider.PlayButtonPressedSignal.PlayButtonPressed += 
				(EventSignalArgs signalArgs) => {
					GetTree().ChangeSceneToFile(ScenePathDictionary.GameScenePath);
				};

			SignalsProvider.ExitButtonPressedSignal.ExitButtonPressed += 
				(EventSignalArgs signalArgs) => {
					GetTree().Quit();
				};
		}
	}
}
