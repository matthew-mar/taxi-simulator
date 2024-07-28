using Godot;
using TaxiSimulator.Scenes.Tab.View;
using TaxiSimulator.Scenes.Tab.Signals;
using MenuSignals = TaxiSimulator.Scenes.Menu.Signals;

namespace TaxiSimulator.Scenes.Tab {
	public partial class TabController : Control {
		private CloseButton _closeButton;

		public override void _Ready() {
			base._Ready();

			_closeButton = GetNode<CloseButton>(CloseButton.NodePath);

			MenuSignals.SignalsProvider.MenuStateChangedSignal.Attach(
				Callable.From((MenuSignals.StateChangedArgs args) => {
					Visible = args.ToState != Menu.MenuState.Lobby;
				})
			);

			_closeButton.ButtonDown += () => {
				Visible = ! Visible;
				SignalsProvider.TabClosedSignal.Emit();
			};
		}
	}
}
