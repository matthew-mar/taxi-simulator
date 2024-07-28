using Godot;
using TaxiSimulator.Scenes.MainMenu.Signals;

namespace TaxiSimulator.Scenes.MainMenu.View {
    public partial class ExitButton : TextureButton {
        public override void _Ready()
        {
            base._Ready();

            ButtonDown += () => {
                SignalsProvider.ExitButtonPressedSignal.Emit();
            };
        }
    }
}
