using Godot;

namespace Suff {
	public partial class Mark : CharacterBody3D {
		public NavigationAgent3D agent;

		public override void _Ready() {
			base._Ready();

			agent = GetNode<NavigationAgent3D>("NavigationAgent3D");
		}
	}
}
