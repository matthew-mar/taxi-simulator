using System.Linq;
using Godot;
using TaxiSimulator.Services.Db;

namespace TaxiSimulator.Scenes.Lobby.View.PlayerCard {
    public partial class Raiting : RichTextLabel {
        public const string NodePath = "player_card/top_panel/raiting_title2";

        public void SetRaiting() {
            var ordersMarksCount = DbService.Instance.DbProvider.OrderRespository.CountByMarks();
            if (!ordersMarksCount.Any()) {
                Text = $"[center][color=#F7CA44]{0}";
                return;
            }
            var count = 0;
            var sum = 0;
            foreach (var markCount in ordersMarksCount) {
                count += markCount.Count;
                sum += (markCount.Count * markCount.Mark) ?? 0;
            }
            var raiting = (float)sum / count;
            Text = $"[center][color=#F7CA44]{raiting}";
        }
    }
}
