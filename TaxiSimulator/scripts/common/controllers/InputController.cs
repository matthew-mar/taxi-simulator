using TaxiSimulator.Scenes.CarScene.Signals;
using TaxiSimulator.Common.Helpers.Dictionary;

using Godot;

namespace TaxiSimulator.Common.Controllers {
	public partial class InputController : Node {
		public override void _Process(double delta) {
			base._Process(delta);


			SignalsProvider.MovingForwardSignal.Emit(new MovingAxisArgs() {
				MovingAxis = Input.GetAxis(
					InputActionDictionary.MoveForward,
					InputActionDictionary.MoveBackward
				),
			});

			SignalsProvider.MovingLeftSignal.Emit(new MovingAxisArgs() {
				MovingAxis = Input.GetAxis(
					InputActionDictionary.MoveLeft,
					InputActionDictionary.MoveRight
				),
			});
		}
	}
}
