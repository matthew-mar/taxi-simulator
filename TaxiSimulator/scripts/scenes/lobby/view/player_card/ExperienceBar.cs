using Godot;

namespace TaxiSimulator.Scenes.Lobby.View.PlayerCard {
    public partial class ExperienceBar : TextureProgressBar {
        public const string NodePath = "player_card/driver_class_panel/driver_progress";

        public void SetValue(float experience) {
            Value = experience % 1000f;
        }
    }
}
