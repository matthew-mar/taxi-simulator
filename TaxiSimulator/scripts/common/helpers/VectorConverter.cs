using DbPackage.Structures;
using Godot;

namespace TaxiSimulator.Common.Helpers {
    public class VectorConverter {
        public static Vector3 FromDb(DbVector vector) => new(vector.X, vector.Y, vector.Z);
    }
}
