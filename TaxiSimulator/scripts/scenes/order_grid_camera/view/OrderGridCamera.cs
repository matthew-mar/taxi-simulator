using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Common.Scenes.MoveableCameraScene.View;
using TaxiSimulator.Scenes.OrderGridCameraScene.Signals;

namespace TaxiSimulator.Scenes.OrderGridCameraScene.View {
    public partial class OrderGridCamera : MoveableCamera {
        private Sprite3D _departureFlag;

        private Sprite3D _destinationFlag;

        public void BlitFlags(Vector3 departurePos, Vector3 destinationPos) {
            ClearFlags();

            var departureScene = GD.Load<PackedScene>(ScenePathDictionary.DepartureScenePath);
            _departureFlag = departureScene.Instantiate<Sprite3D>();
            GetTree().Root.AddChild(_departureFlag);
            _departureFlag.GlobalPosition = departurePos;

            var destinationScene = GD.Load<PackedScene>(ScenePathDictionary.DestinationScenePath);
            _destinationFlag = destinationScene.Instantiate<Sprite3D>();
            GetTree().Root.AddChild(_destinationFlag);
            _destinationFlag.GlobalPosition = destinationPos;

            SignalsProvider.FlagsBlitedSignal.Emit(new FlagsBlitedArgs() {
                DeparturePos = departurePos,
                DestinationPos = destinationPos,
            });
        }

        public void ClearFlags() {
            _departureFlag?.QueueFree();
            _departureFlag = null;

            _destinationFlag?.QueueFree();
            _destinationFlag = null;
        }
    }
}
