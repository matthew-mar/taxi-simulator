using Godot;

namespace TaxiSimulator.Scenes.Lobby.View.PlayerCard {
    public partial class Balance : RichTextLabel {
        public const string NodePath = "player_card/balance_panel/panel_cost";

        public void SetBalance(float balance) {
            Text = $"[center][color=#F7CA44]{balance} ₽";
        }
    }
}
