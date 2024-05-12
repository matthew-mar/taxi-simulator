using TaxiSimulator.Common;
using TaxiSimulator.Services.Game;
using TaxiSimulator.Scenes.GameScene.Signals;

using PuaseSignals = TaxiSimulator.Scenes.Pause.Signals;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;

using Godot;
using System;
using System.Collections.Generic;

namespace TaxiSimulator.Scenes.GameScene {
	public enum GameMode {
		Game,
		Pause,
		Map,
		OrderGrid,
	}

	public partial class GameSceneController : Node3D {
		private GameMode _currentGameMode = GameMode.Game;

		private GameMode _previousGameMode;

		private Dictionary<GameMode, Control> _modes;

		public override void _Ready() {
			base._Ready();

			_modes = new() {
				{ GameMode.Map, GetNode<Control>("map_controller") },
				{ GameMode.Game, GetNode<Control>("Enviroment") },
				{ GameMode.OrderGrid, GetNode<Control>("orders_grid") },
			};
			
			ChangeGameMode(GameService.Instance.GameMode);

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

					if (_currentGameMode == GameMode.Map) {
						ChangeGameMode(GameMode.Game);
						return;
					}

					ChangeGameMode(GameMode.Map);
				})
			);

			OrderSignals.SignalsProvider.OrderTakenSignal.Attach(
				Callable.From((OrderSignals.OrderArgs args) => {
					if (_currentGameMode == GameMode.Pause) {
						return;
					}

					ChangeGameMode(GameMode.Game);
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

			foreach (var map in _modes) {
				_modes[map.Key].Visible = map.Key == _currentGameMode;
				// _modes[map.Key].ProcessMode = map.Key == _currentGameMode
				// 	? ProcessModeEnum.Always
				// 	: ProcessModeEnum.Disabled;
			}

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
