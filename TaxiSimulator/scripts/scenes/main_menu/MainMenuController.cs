using TaxiSimulator.Common;
using TaxiSimulator.Scenes.MainMenu.Signals;

using Godot;
using TaxiSimulator.Services.Game;

namespace TaxiSimulator.Scenes.MainMenu {

	public partial class MainMenuController : Control {
		public override void _Ready() {
			base._Ready();

			SignalsProvider.PlayButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs signalArgs) => {
					GameService.Instance.SwitchToMenu();
				})
			);

			SignalsProvider.ExitButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs signalArgs) => {
					GetTree().Quit();
				})
			);
		}
	}
}
