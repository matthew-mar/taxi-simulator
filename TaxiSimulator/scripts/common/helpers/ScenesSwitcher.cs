using Godot;
using TaxiSimulator.Common.Contracts.Controllers;

namespace TaxiSimulator.Common.Helpers {
	public class SceneSwitcher {
		public static void SwitchScene(string scenePath, Node fromScene)
			=> fromScene.GetTree().ChangeSceneToFile(scenePath);
	}
}
