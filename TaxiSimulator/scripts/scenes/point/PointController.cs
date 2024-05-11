using Godot;
using TaxiSimulator.Common.View;
using TaxiSimulator.Scenes.Point.Signals;

namespace TaxiSimulator.Scenes.Point {
	public partial class PointController : CharacterBody3D {
		private CollisionArea _collisionArea;

		public override void _Ready() {
			base._Ready();

			_collisionArea = GetNode<CollisionArea>(CollisionArea.NodePath);

			_collisionArea.BodyEntered += (Node3D body) => {
				_collisionArea.CheckEnterd(body);
				if (_collisionArea.CarStayed) {
					SignalsProvider.PointReachedSignal.Emit();
				}
			};
		}
	}
}
