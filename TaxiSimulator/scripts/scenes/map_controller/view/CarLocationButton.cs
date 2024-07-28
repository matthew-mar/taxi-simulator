using Godot;
using TaxiSimulator.Scenes.MapController.Signals;

namespace TaxiSimulator.Scenes.MapController.View {
	public partial class CarLocationButton : TextureButton {
		public override void _Ready() {
			base._Ready();

			ButtonDown += () => {
				SignalsProvider.CarLocationButtonPressedSignal.Emit();
			};
		}
	}
}
