using Godot;
using TaxiSimulator.Scenes.Pause.Signals;

namespace TaxiSimulator.Scenes.Pause.View {

	public partial class MainMenuButton : TextureButton {
		public override void _Ready() {
			base._Ready();

			ButtonDown += () => {
				SignalsProvider.MainMenuButtonPressed.Emit();
			};
		}
	}
}
