using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Common.Helpers.Dictionary;

using DbSignals = TaxiSimulator.Services.Db.Signals;
using TabSignals = TaxiSimulator.Scenes.Tab.Signals;
using MenuSignals = TaxiSimulator.Scenes.Menu.Signals;
using LobbySignals = TaxiSimulator.Scenes.Lobby.Signals;
using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSignals = TaxiSimulator.Scenes.GameScene.Signals;
using PlayerSignal = TaxiSimulator.Services.Player.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Signals;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;
using GasolineSignals = TaxiSimulator.Scenes.Gasoline.Signals;
using MainMenuSignals = TaxiSimulator.Scenes.MainMenu.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using MapCameraSignals = TaxiSimulator.Scenes.MapCameraScene.Signals;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;
using TaxiSimulator.Scenes.GameScene;

namespace TaxiSimulator.Services.Game {
	public partial class GameService : Node {
		public static GameService Instance { get; private set; }

		private bool _reload = false;

		public GameMode GameMode { get; private set; }

		public override void _Ready() {
			base._Ready();

			Instance ??= this;

			Attach();
		}

		public override void _Process(double delta) {
			base._Process(delta);

			if (! _reload) {
				return;
			}

			Attach();
			_reload = false;
		}

		public void SwitchToMain() => SceneSwitcher.SwitchScene(
			ScenePathDictionary.MainMenuScenePath,
			GetTree().CurrentScene
		);

		public void SwitchToGame() => SceneSwitcher.SwitchScene(
			ScenePathDictionary.GameScenePath,
			GetTree().CurrentScene
		);

		public void SwitchToMenu() => SceneSwitcher.SwitchScene(
			ScenePathDictionary.MenuScenePath,
			GetTree().CurrentScene
		);

		private void Pause() => GetTree().Paused = ! GetTree().Paused;

		private static void ClearSignals() {
			PauseSignals.SignalsProvider.ClearSignals();
			CarSignals.SignalsProvider.ClearSignals();
			GameSignals.SignalsProvider.ClearSignals();
			PlayerSignal.SignalsProvider.ClearSingals();
			ParkingSignals.SignalsProvider.ClearSignals();
			GasolineSignals.SignalsProvider.ClearSignals();
			MainMenuSignals.SignalsProvider.ClearSignals();
			MapSignals.SignalsProvider.ClearSignals();
			InputSignals.SignalsProvider.ClearSignals();
			MapCameraSignals.SignalsProvider.ClearSignals();
			NavigationMarkSignals.SignalsProvider.ClearSignals();
			LobbySignals.SignalsProvider.ClearSignals();
			TabSignals.SignalsProvider.ClearSignals();
			MenuSignals.SignalsProvider.ClearSignals();
			DbSignals.SignalsProvider.ClearSignals();
			OrderSignals.SignalsProvider.ClearSignals();
		}

		private void Attach() {
			DbSignals.SignalsProvider.DatabaseInitializedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					GD.Print("Db initialized");
					CallDeferred(nameof(SwitchToMain));
				})
			);

			PauseSignals.SignalsProvider.ContinueButtonPressed.Attach(
				Callable.From((EventSignalArgs args) => {
					CallDeferred(nameof(Pause));
				})
			);

			InputSignals.SignalsProvider.EscapePressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					CallDeferred(nameof(Pause));
				})
			);

			PauseSignals.SignalsProvider.MainMenuButtonPressed.Attach(
				Callable.From((EventSignalArgs args) => {
					CallDeferred(nameof(Pause));
					CallDeferred(nameof(ClearSignals));
					CallDeferred(nameof(SwitchToMenu));
					_reload = true;
				})
			);

			LobbySignals.SignalsProvider.DriveButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					GameMode = GameMode.Game;
					CallDeferred(nameof(SwitchToGame));
					// _reload = true;
				})
			);

			LobbySignals.SignalsProvider.MapButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					GameMode = GameMode.Map;
					CallDeferred(nameof(ClearSignals));
					CallDeferred(nameof(SwitchToGame));
					_reload = true;
				})
			);

			LobbySignals.SignalsProvider.QuitButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					CallDeferred(nameof(ClearSignals));
					CallDeferred(nameof(SwitchToMain));
					_reload = true;
				})
			);

			LobbySignals.SignalsProvider.OrdersButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					GameMode = GameMode.OrderGrid;
					CallDeferred(nameof(ClearSignals));
					CallDeferred(nameof(SwitchToGame));
					_reload = true;
				})
			);

			GameSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSignals.GameModeChangedArgs args) => {
					GameMode = args.To;
				})
			);
		}
	}
}
