using Godot;
using TaxiSimulator.Common.View;
using TaxiSimulator.Scenes.Parking.Signals;
using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.Parking {
	public partial class ParkingController : Node3D {
		private CollisionArea _collisionArea;

		public override void _Ready() {
			base._Ready();

			_collisionArea = GetNode<CollisionArea>(CollisionArea.NodePath);

			_collisionArea.BodyEntered += (Node3D body) => {
				_collisionArea.CheckEnterd(body);
				if (_collisionArea.CarStayed) {
					SignalsProvider.CarEnteredSignal.Emit();
				}
			};

			_collisionArea.BodyExited += (Node3D body) => {
				_collisionArea.CheckLeft(body);

				if (_collisionArea.CarStayed) {
					return;
				}

				SignalsProvider.CarLeftSignal.Emit();
			};

			InputSignals.SignalsProvider.ActionEPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					SignalsProvider.RestAllowedSignal.Emit(new RestAllowedArgs() {
						Allowed = _collisionArea.CarStopedInArea,
						ParkingPosition = _collisionArea.GlobalPosition,
					});
				})
			);

			PauseSignals.SignalsProvider.MainMenuButtonPressed.Attach(
				Callable.From((EventSignalArgs args) => {
					SignalsProvider.ClearSignals();
				})
			);
		}

		public override void _Process(double delta) {
			base._Process(delta);

			SignalsProvider.CarStayedSignal.Emit(new CarStayedArgs() {
				CarStayed = _collisionArea.CarStayed,
			});

			SignalsProvider.PositionBlitSignal.Emit(new PositionBlitArgs() {
				ParkingId = _collisionArea.GetRid(),
				ParkingPosition = _collisionArea.GlobalPosition,
			});
		}
	}
}
