using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.Pause.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

using Godot;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using TaxiSimulator.Services.Game;
using TaxiSimulator.Scenes.Pause.View;

namespace TaxiSimulator.Scenes.Pause {

	public partial class PauseController : Control {
		private Control _innerController;

		private MainMenuButton _mainMenuButton;

		private ContinueButton _continueButton;

		public override void _Ready() {
			base._Ready();

			_innerController = GetNode<Control>("Control");
			_mainMenuButton = GetNode<MainMenuButton>(MainMenuButton.NodePath);
			_continueButton = GetNode<ContinueButton>(ContinueButton.NodePath);

			_continueButton.ButtonDown += () => {
				SwitchVisible();
				SignalsProvider.ContinueButtonPressed.Emit();
			};

			_mainMenuButton.ButtonDown += () => {
				SwitchVisible();
				SignalsProvider.MainMenuButtonPressed.Emit();
			};

			InputSignals.SignalsProvider.EscapePressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					SwitchVisible();
				})
			);
		}

		private void SwitchVisible() {
			_innerController.Visible = ! _innerController.Visible;
		}
	}
}
