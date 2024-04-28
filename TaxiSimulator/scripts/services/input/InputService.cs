using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Services.InputService.Signlas;

using Godot;

namespace TaxiSimulator.Services.InputService {
    public partial class InputService : Node {
        public static InputService Instance { get; private set; }

        public override void _Ready() {
            base._Ready();

            Instance ??= this;
        }

        public override void _Input(InputEvent @event) {
            base._Input(@event);

            if (@event.IsActionPressed(InputActionDictionary.ActionC)) {
                SignalsProvider.ActionCPressedSignal.Emit();
            }

            if (@event.IsActionPressed(InputActionDictionary.ActionE)) {
                SignalsProvider.ActionEPressedSignal.Emit();
            }

            if (@event.IsActionPressed(InputActionDictionary.ActionM)) {
                SignalsProvider.ActionMPressedSignal.Emit();
            }

            if (@event.IsActionPressed(InputActionDictionary.Esc)) {
                var instanceId = SignalsProvider.EscapePressedSignal.GetInstanceId();
                SignalsProvider.EscapePressedSignal.Emit();
            }

            if (@event.IsActionPressed(InputActionDictionary.LeftClick)) {
                SignalsProvider.MouseLeftClickedSignal.Emit();
            }

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
        }
    }
}
