using TaxiSimulator.Common.Contracts.Controllers;

namespace TaxiSimulator.Common.Helpers {
    public class SceneSwitcher {
        public static void SwitchScene(string scenePath, ISceneController fromScene) {
            fromScene.ClearSignals();
            fromScene.GetNode().GetTree().ChangeSceneToFile(scenePath);
        }
    }
}
