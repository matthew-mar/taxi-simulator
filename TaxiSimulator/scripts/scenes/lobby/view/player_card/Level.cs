using Godot;

namespace TaxiSimulator.Scenes.Lobby.View.PlayerCard {
    public partial class Level : RichTextLabel {
        public const string NodePath = "player_card/level_panel/driver_class_title2";

        public void SetLevel(float experience) {
            var level = (int)(experience / 1000f);
            Text = $"[center][color=#F7CA44]{level}";
        }
    }
}
