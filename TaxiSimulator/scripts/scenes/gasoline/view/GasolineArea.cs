using TaxiSimulator.Scenes.CarScene.View;
using TaxiSimulator.Scenes.Gasoline.Signals;

using Godot;

namespace TaxiSimulator.Scenes.Gasoline.View {
    public partial class GasolineArea : Area3D {
        public const string NodePath = "GasolineArea";

        private Car _car = null;

        public void CheckEntered(Node body) {
            if (body is Car car) {
                _car = car;
                SignalsProvider.CarEnteredSignal.Emit();
            }
        }

        public void CheckLeft(Node body) {
            if (body is Car) {
                _car = null;
                SignalsProvider.CarLeftSignal.Emit();
            }
        }

        public void CheckStay() => SignalsProvider.CarStayedSignal.Emit(new CarStayedArgs() {
            CarStayed = _car != null,
        });

        public void CheckRefuelAllowed() {
            SignalsProvider.RefuelAllowedSignal.Emit(new RefuelAllowedArgs() {
                Allowed = (_car != null) && ((int)_car.SpeedMs == 0),
            });
        }
    }
}
