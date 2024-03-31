using TaxiSimulator.Common.Helpers.Dictionary;
using PauseSceneSignals = TaxiSimulator.Scenes.Pause.Signals;
using CarSceneSignals = TaxiSimulator.Scenes.CarScene.Signals;

using Godot;

namespace TaxiSimulator.Common.Controllers {
	public partial class InputController : Node {
		public override void _Process(double delta) {
			base._Process(delta);

			CarSceneSignals.SignalsProvider.MovingVerticalSignal.Emit(
				new CarSceneSignals.MovingAxisArgs() {
					MovingAxis = Input.GetAxis(
						InputActionDictionary.MoveBackward,
						InputActionDictionary.MoveForward
					),
				}
			);

			CarSceneSignals.SignalsProvider.MovingHorizontalSignal.Emit(
				new CarSceneSignals.MovingAxisArgs() {
					MovingAxis = Input.GetAxis(
						InputActionDictionary.MoveRight,
						InputActionDictionary.MoveLeft
					),
				}
			);

			if (Input.IsActionJustPressed(InputActionDictionary.Pause)) {
				PauseSceneSignals.SignalsProvider.ContinueButtonPressed.Emit();
			}
		}
	}
}
