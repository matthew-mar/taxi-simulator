using Godot;
using System.IO;
using TaxiSumulatorDb;

using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Contracts.Controllers;

namespace TaxiSimulator.Scenes.GameManager {
	public partial class GameManagerController : Node, ISceneController {
		private static GameManagerController instance = null;

		public static GameManagerController Instance => instance;

		public override async void _Ready() {
			base._Ready();

			instance ??= this;

			var fullPath = ProjectSettings.GlobalizePath(TaxiSumulatorDbContext.DatabaseFileName);
			var dbProvider = new TaxiSimulatorDbProvider(fullPath);
			using var connection = dbProvider.Context;
			await connection.MakeMigrationsAsync();
			GD.Print("migrated");

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
