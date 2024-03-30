using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.MainMenu.Signals;

using Godot;

namespace TaxiSimulator.Scenes.MainMenu {

	public partial class MainMenuController : Control {
		public override void _Ready() {
			base._Ready();

			SignalsProvider.PlayButtonPressedSignal.PlayButtonPressed += 
				(EventSignalArgs signalArgs) => {
					GetTree().ChangeSceneToFile(DictionaryService.GameScenePath);
				};

			SignalsProvider.ExitButtonPressedSignal.ExitButtonPressed += 
				(EventSignalArgs signalArgs) => {
					GetTree().Quit();
				};
		}
	}
}
