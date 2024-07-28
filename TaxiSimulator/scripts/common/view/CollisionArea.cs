using Godot;
using TaxiSimulator.Scenes.CarScene.View;

namespace TaxiSimulator.Common.View {
	public partial class CollisionArea : Area3D {
		public const string NodePath = "CollisionArea";

		private Car _car = null;

		public bool CarStayed => _car != null;

		public bool CarStopedInArea => CarStayed && ((int)_car.SpeedMs == 0);

		public void CheckEnterd(Node body) {
			if (body is Car car) {
				_car = car;
			}
		}

		public void CheckLeft(Node body) {
			if (body is Car) {
				_car = null;
			}
		}
	}
}
