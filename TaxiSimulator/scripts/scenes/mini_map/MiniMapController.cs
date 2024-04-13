using TaxiSimulator.Scenes.MiniMap.View;
using GasolineSignals = TaxiSimulator.Scenes.Gasoline.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;

using Godot;
using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers.Dictionary;

namespace TaxiSimulator.Scenes.MiniMap {
	public partial class MiniMapController : Control {
		private bool _checkSignals = true;

		private float _carSpeed;

		public override void _Ready() {
			base._Ready();

			var speedText = GetNode<SpeedText>(SpeedText.NodePath);
			var suggestion = GetNode<ColorRect>("MarginContainer/MiniMapBase/Suggestion");
			var mapContainer = GetNode<MarginContainer>("MarginContainer/MiniMapBase/MarginContainer");
			var suggestionText = GetNode<SuggestionText>(SuggestionText.NodePath);
			var fuelBar = GetNode<FuelBar>(FuelBar.NodePath);

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.GameModeChanged += 
				(GameSceneSignals.GameModeChangedArgs args) => {
					_checkSignals = args.To == GameScene.GameMode.Game;
				};

			CarSceneSignals.SignalsProvider.SpeedChangedSignal.SpeedChanged +=
				(CarSceneSignals.SpeedSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					speedText.SetSpeed(args.CurrentSpeed);
					_carSpeed = args.CurrentSpeed.Length();
				};

			CarSceneSignals.SignalsProvider.FuelChangedSignal.FuelChanged +=
				(CarSceneSignals.FuelChangedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					fuelBar.SetFuelLevel(args.FuelLevel);
				};

			GasolineSignals.SignalsProvider.CarStayedSignal.CarStayed += 
				(GasolineSignals.CarStayedArgs args) => {
					if (! _checkSignals) {
						return;
					}

					if (! args.CarStayed) {
						return;
					}

					ChangeNode(mapContainer, suggestion);
					if ((int)_carSpeed != 0) {
						suggestionText.SetText(GameTextsDictionary.StopCarSuggestion);
						return;
					}
					
					suggestionText.SetText(GameTextsDictionary.RefuelSuggestion);
				};

			GasolineSignals.SignalsProvider.CarLeftSignal.CarLeft +=
				(EventSignalArgs args) => {
					if (! _checkSignals) {
						return;
					}

					ChangeNode(suggestion, mapContainer);
				};
		}

		private static void ChangeNode(Control from, Control to) {
			from.Visible = false;
			to.Visible = true;
		}
	}
}
