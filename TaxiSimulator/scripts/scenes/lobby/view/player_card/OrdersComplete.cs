using Godot;
using TaxiSimulator.Services.Db;

namespace TaxiSimulator.Scenes.Lobby.View.PlayerCard {
    public partial class OrdersComplete : RichTextLabel {
        public const string NodePath = "player_card/orders_panel/panel_cost";

        public async void SetOrders() {
            var completed = await DbService.Instance
                .DbProvider
                .OrderRespository
                .CountByCompletedStatusAsync(true);
            Text = $"[center][color=#F7CA44]{completed}";
        }
    }
}
