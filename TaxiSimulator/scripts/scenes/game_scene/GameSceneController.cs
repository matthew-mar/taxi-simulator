using TaxiSimulator.Common;
using TaxiSimulator.Scenes.GameScene.Signals;

using PuaseSignals = TaxiSimulator.Scenes.Pause.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;

using Godot;
using System;

namespace TaxiSimulator.Scenes.GameScene {
	public enum GameMode {
		Game,
		Pause,
		Map,
	}

	public partial class GameSceneController : Node3D {
		private GameMode _currentGameMode = GameMode.Game;

		private GameMode _previousGameMode;

		public override void _Ready() {
			base._Ready();

			ChangeGameMode(GameMode.Game);

			var map = GetNode<Control>("map_controller");
			var enviroment = GetNode<Control>("Enviroment");

			InputSignals.SignalsProvider.EscapePressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (_currentGameMode != GameMode.Pause) {
						ChangeGameMode(GameMode.Pause);
					} else {
						ChangeGameMode(_previousGameMode);
					}
				})
			);

			PuaseSignals.SignalsProvider.ContinueButtonPressed.Attach(
				Callable.From((EventSignalArgs args) => {
					if (_currentGameMode != GameMode.Pause) {
						throw new Exception("Can't continue game cause game is not in PauseMode");
					}

					ChangeGameMode(_previousGameMode);
				})
			);

			InputSignals.SignalsProvider.ActionMPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (_currentGameMode == GameMode.Pause) {
						return;
					}
					
					map.Visible = ! map.Visible;
					enviroment.Visible = ! enviroment.Visible;

					if (_currentGameMode == GameMode.Map) {
						ChangeGameMode(GameMode.Game);
						return;
					}

					ChangeGameMode(GameMode.Map);
				})
			);
		}

		public override void _Process(double delta) {
			base._Process(delta);

			SendGameMode();
		}

		private void ChangeGameMode(GameMode gameMode) {
			_previousGameMode = _currentGameMode;
			_currentGameMode = gameMode;
			SignalsProvider.GameModeChangedSignal.Emit(new GameModeChangedArgs() {
				From = _previousGameMode,
				To = _currentGameMode,
			});
		}

		private void SendGameMode() => SignalsProvider.CurrentGameModeSignal.Emit(
			new CurrentGameModeArgs() {
				CurrentGameMode = _currentGameMode,
			}
		);
	}
}
