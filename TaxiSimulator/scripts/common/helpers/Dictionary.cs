namespace TaxiSimulator.Common.Helpers.Dictionary {

    public class ScenePathDictionary {
        public const string GameScenePath = "res://scenes/game_scene/game_scene.tscn";

        public const string MainMenuScenePath = "res://scenes/main_menu/main_menu.tscn";

        public const string MenuScenePath = "res://scenes/menu/menu.tscn";

        public const string OrderCardScenePath = "res://scenes/order_card/order_card.tscn";

        public const string PaginationItemScenePath = "res://scenes/pagination_item/pagination_item.tscn";

        public const string DepartureScenePath = "res://scenes/Map/departure.tscn";

        public const string DestinationScenePath = "res://scenes/Map/destination.tscn";

        public const string MarkScenePath = "res://scenes/navigation_point/navigation_point.tscn";
    }

    public class InputActionDictionary {
        public const string MoveForward = "MoveForward";
        
        public const string MoveBackward = "MoveBackward";
        
        public const string MoveRight = "MoveRight";

        public const string MoveLeft = "MoveLeft";

        public const string Esc = "Esc";

        public const string WheelScrollForward = "WheelScrollForward";

        public const string WheelScrollBackward = "WheelScrollBackward";

        public const string ActionM = "ActionM";

        public const string LeftClick = "LeftClick";

        public const string ActionC = "ActionC";

        public const string ActionE = "ActionE";
    }

    public class GameTextsDictionary {
        public const string StopCarSuggestion = "остановите машину";

        public const string RefuelSuggestion = "нажмите [E] для заправки";

        public const string RestSuggestion = "нажмите [E] для отдыха";
    }
}
