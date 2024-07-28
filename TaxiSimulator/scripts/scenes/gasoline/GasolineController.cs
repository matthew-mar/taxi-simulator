using Godot;
using TaxiSimulator.Common;
using TaxiSimulator.Scenes.Gasoline.Signals;
using TaxiSimulator.Scenes.Gasoline.View;
using PauseSignals = TaxiSimulator.Scenes.Pause.Signals;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;
using TaxiSimulator.Common.View;

namespace TaxiSimulator.Scenes.Gasoline {
	public partial class GasolineController : Node3D {
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
				if (! _collisionArea.CarStayed) {
					SignalsProvider.CarLeftSignal.Emit();
				}
			};

			InputSignals.SignalsProvider.ActionEPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					SignalsProvider.RefuelAllowedSignal.Emit(new RefuelAllowedArgs() {
						Allowed = _collisionArea.CarStopedInArea,
					});
				})
			);
		}

		public override void _Process(double delta) {
			base._Process(delta);

			SignalsProvider.CarStayedSignal.Emit(new CarStayedArgs() {
				CarStayed = _collisionArea.CarStayed,
			});
		}
	}
}
