using Godot;
using TaxiSimulator.Scenes.MainMenu.Signals;

namespace TaxiSimulator.Scenes.MainMenu.UI {
    public partial class PlayButton : TextureButton {
        public override void _Ready() {
            base._Ready();

            ButtonDown += () => {
                SignalsProvider.PlayButtonPressedSignal.Emit();
            };
        }
    }
}
