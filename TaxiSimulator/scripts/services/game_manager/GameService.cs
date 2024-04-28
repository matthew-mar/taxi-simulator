using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Common.Helpers.Dictionary;

using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSignals = TaxiSimulator.Scenes.GameScene.Signals;
using PlayerSignal = TaxiSimulator.Services.Player.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Singlas;
using GasolineSignals = TaxiSimulator.Scenes.Gasoline.Signals;
using MainMenuSignals = TaxiSimulator.Scenes.MainMenu.Signals;
using MapSignals = TaxiSimulator.Scenes.MapController.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using MapCameraSignals = TaxiSimulator.Scenes.MapCameraScene.Signals;
using NavigationMarkSignals = TaxiSimulator.Scenes.NavigationMark.Signals;

using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Services.Game {
	public partial class GameService : Node {
		public static GameService Instance { get; private set; }

		private bool _reload = false;

		public override void _Ready() {
			base._Ready();

			Instance ??= this;

			Attach();

			CallDeferred(nameof(SwitchToMain));
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
		}

		private void Attach() {
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
					CallDeferred(nameof(SwitchToMain));
					_reload = true;
				})
			);
		}
	}
}
