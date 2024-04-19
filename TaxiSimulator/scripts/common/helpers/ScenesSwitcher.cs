using Godot;
using TaxiSimulator.Common.Contracts.Controllers;

namespace TaxiSimulator.Common.Helpers {
	public class SceneSwitcher {
		public static void SwitchScene(string scenePath, ISceneController fromScene) {
			fromScene.ClearSignals();

			GD.Print(fromScene.GetNewNode().GetTree() == null);

			fromScene.GetNewNode().GetTree().ChangeSceneToFile(scenePath);
		}
	}
}
