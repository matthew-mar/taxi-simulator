using System.Xml.Schema;
using Godot;
using TaxiSimulator.Scenes.CarScene.Signals;
using TaxiSimulator.Scenes.RearView.View;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;

namespace TaxiSimulator.Scenes.RearView { 
    public partial class RearViewController : Node3D {
        private RearViewCamera _camera;

        public override void _Ready() {
            base._Ready();

            _camera = GetNode<RearViewCamera>(RearViewCamera.NodePath);

            CarSignals.SignalsProvider.PositionChangedSignal.Attach(
                Callable.From((CarSignals.PositionSignalArgs args) => {
                    _camera.FollowTargetPosition(args.CurrentPosition);
                })
            );

            CarSignals.SignalsProvider.RotationChangedSignal.Attach(
                    Callable.From((RotationSignalArgs  args) => {
                        _camera.FollowTargetRotation(new Vector3(
                            args.CurrentRotation.X,
                            args.CurrentRotation.Y - 180,
                            args.CurrentRotation.Z
                        ));
                })
            );
        }
    }
}
