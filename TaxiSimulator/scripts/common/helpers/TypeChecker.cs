using Godot;

namespace TaxiSimulator.Common.Helpers {
    public class TypeChecker {
        public static bool IsVisible(Node node) {
            return (
                (node is Node3D) ||
                (node is Control) ||
                (node is DirectionalLight3D)
            );
        }
    }
}
