using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;

public partial class TestCamera : Camera3D {
    public Vector3 TargetPoint {
        get {
            var mousePos = GetViewport().GetMousePosition();
            var from = ProjectRayOrigin(mousePos);
            var to = from + ProjectRayNormal(mousePos) * 1000;
            var space = GetWorld3D().DirectSpaceState;
            var rawQuery = new PhysicsRayQueryParameters3D
            {
                From = from,
                To = to,
            };
            var raycastResult = space.IntersectRay(rawQuery);
            var returnPosition = (Vector3)raycastResult["position"];

            return returnPosition;
        }
    }
}
