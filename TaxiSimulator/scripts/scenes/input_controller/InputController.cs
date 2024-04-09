using TaxiSimulator.Common;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Scenes.InputController.Signlas;
using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;

using Godot;
using System;

namespace TaxiSimulator.Scenes.InputController {
	public partial class InputController : Node {
        public override void _Ready() {
            base._Ready();

			PauseSignals.SignalsProvider.MainMenuButtonPressed.MainMenuButtonPressed +=
				(EventSignalArgs args) => {
					SignalsProvider.ClearSignals();
				};
        }

        public override void _Process(double delta) {
			base._Process(delta);

			SignalsProvider.VerticalPressedSignal.Emit(new VerticalPressedArgs() {
				VerticalAxis = Input.GetAxis(
					InputActionDictionary.MoveBackward,
					InputActionDictionary.MoveForward
				),
			});

			SignalsProvider.HorizontalPressedSignal.Emit(new HorizontalPressedArgs() {
				HorizontalAxis = Input.GetAxis(
					InputActionDictionary.MoveRight,
					InputActionDictionary.MoveLeft
				),
			});

			if (Input.IsActionJustPressed(InputActionDictionary.Esc)) {
				SignalsProvider.EscapePressedSignal.Emit();
			}

			if (Input.IsActionJustPressed(InputActionDictionary.ActionM)) {
				SignalsProvider.ActionMPressedSignal.Emit();
			}

			if (Input.IsActionJustPressed(InputActionDictionary.ActionC)) {
				SignalsProvider.ActionCPressedSignal.Emit();
			}
		}

        public override void _Input(InputEvent @event) {
            base._Input(@event);

			if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed) {
				switch (mouseButton.ButtonIndex) {
					case MouseButton.WheelUp:
						SignalsProvider.MouseScrolledUpSignal.Emit();
						break;

					case MouseButton.WheelDown:
						SignalsProvider.MouseScrolledDownSignal.Emit();
						break;

					default: break;
				}
			}
        }
    }
}
