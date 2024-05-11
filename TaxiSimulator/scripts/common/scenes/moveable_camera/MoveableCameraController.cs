using Godot;
using TaxiSimulator.Common.Scenes.MoveableCameraScene.View;
using InputSignals = TaxiSimulator.Services.InputService.Signlas;

namespace TaxiSimulator.Common.Scenes.MoveableCameraScene {
	public partial class MoveableCameraController : Node3D {
		protected MoveableCamera _camera;

		protected virtual bool Active { get; }

		public override void _Ready() {
			base._Ready();

			_camera = GetNode<MoveableCamera>(MoveableCamera.NodePath);

			InputSignals.SignalsProvider.VerticalPressedSignal.Attach(
				Callable.From((InputSignals.VerticalPressedArgs args) => {
					if (! Active) {
						return;
					}
					_camera.MoveVertical(args.VerticalAxis);
				})
			);

			InputSignals.SignalsProvider.HorizontalPressedSignal.Attach(
				Callable.From((InputSignals.HorizontalPressedArgs args) => {
					if (! Active) {
						return;
					}
					_camera.MoveHorizontal(args.HorizontalAxis);
				})
			);

			InputSignals.SignalsProvider.MouseScrolledUpSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Active) {
						return;
					}
					_camera.ZoomIn();
				})
			);

			InputSignals.SignalsProvider.MouseScrolledDownSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					if (! Active) {
						return;
					}
					_camera.ZoomOut();
				})
			);
		}
	}
}
