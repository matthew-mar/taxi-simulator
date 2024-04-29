namespace TaxiSimulator.Common.Helpers.Dictionary {

    public class ScenePathDictionary {
        public const string GameScenePath = "res://scenes/game_scene/game_scene.tscn";

        public const string MainMenuScenePath = "res://scenes/main_menu/main_menu.tscn";

        public const string MenuScenePath = "res://scenes/menu/menu.tscn";
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
