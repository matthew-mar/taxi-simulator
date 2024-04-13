using Godot;
using TaxiSimulator.Common;
using TaxiSimulator.Scenes.Gasoline.Signals;
using TaxiSimulator.Scenes.Gasoline.View;
using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using InputSignals = TaxiSimulator.Scenes.InputController.Signlas;

namespace TaxiSimulator.Scenes.Gasoline {
	public partial class GasolineController : Node3D {
		private GasolineArea _gasolineArea;

		public override void _Ready() {
			base._Ready();

			_gasolineArea = GetNode<GasolineArea>(GasolineArea.NodePath);
			_gasolineArea.BodyEntered += _gasolineArea.CheckEntered;
			_gasolineArea.BodyExited += _gasolineArea.CheckLeft;

			PauseSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed +=
				(EventSignalArgs args) => {
					SignalsProvider.ClearSignals();  
				};

			InputSignals.SignalsProvider.ActionEPressedSignal.ActionEPressed +=
				(EventSignalArgs args) => {
					_gasolineArea.CheckRefuelAllowed();  
				};
		}

		public override void _Process(double delta) {
			base._Process(delta);

			_gasolineArea.CheckStay();
		}
	}
}
