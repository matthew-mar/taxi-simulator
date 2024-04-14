using Godot;

namespace TaxiSimulator.Scenes.CarScene.View {
    public partial class SteerWheel : MeshInstance3D {
        public const string NodePath = "car_copy_1/Body/SteerWheel";

        private float angle = 0f;
        private float steeringWheelMaxAngle = 720f;
        private float wheelsMaxSteering = 30f;
        private float currentSteeringWheelAngle = 0f;

        public void RotateWheel(float steering) {
            var steeringRatio = steeringWheelMaxAngle / wheelsMaxSteering;
            var targetSteeringWheelAngle = steering * steeringRatio;
            var angleDifference = targetSteeringWheelAngle - currentSteeringWheelAngle;
            var angleDifferenceRadians = Mathf.DegToRad(angleDifference);
            RotateObjectLocal(Vector3.Up, angleDifferenceRadians * 50f);
            currentSteeringWheelAngle = targetSteeringWheelAngle;
        }
    }
}
