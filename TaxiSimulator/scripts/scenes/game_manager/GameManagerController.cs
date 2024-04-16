using Godot;
using TaxiSimulator.Common.Contracts.Controllers;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Common.Helpers.Dictionary;

namespace TaxiSimulator.Scenes.GameManager {
	public partial class GameManagerController : Node, ISceneController {
		private static GameManagerController instance = null;

		public static GameManagerController Instance => instance;

		public override void _Ready() {
			base._Ready();

			instance ??= this;
			CallDeferred(nameof(SwitchScene), ScenePathDictionary.MainMenuScenePath);
		}

		public void ClearSignals() {

		}

		public Node GetNode() => this;

		public void SwitchScene(string scenePath) {
			SceneSwitcher.SwitchScene(scenePath, this);
		}
	}
}
