using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Common.Contracts.Controllers;
using TaxiSimulator.Common.Helpers.Dictionary;

using Godot;
using System.IO;
using TaxiSimulatorDb;

namespace TaxiSimulator.Scenes.GameManager {
	public partial class GameManagerController : Node, ISceneController {
		private static GameManagerController instance = null;

		public static GameManagerController Instance => instance;

		public override async void _Ready() {
			base._Ready();

			instance ??= this;

			var fullPath = ProjectSettings.GlobalizePath(
				TaxiSimulatorDbContextFactory.DatabaseFileName
			);
			var dbProvider = new TaxiSimulatorDbProvider(fullPath);

			if (! File.Exists(fullPath)) {
				using var connection = dbProvider.Context;
				await connection.MakeMigrationsAsync();
			}

			CallDeferred(nameof(SwitchScene), ScenePathDictionary.MainMenuScenePath);
		}

		public void SwitchScene(string scenePath) => SceneSwitcher.SwitchScene(scenePath, this);
		
		public void ClearSignals() {}

		public Node GetNewNode() => this;
	}
}
