using System.Collections.Generic;
using Godot;
using Godot.NativeInterop;

public partial class TestNode : Node3D {
    public override void _Ready() {
        base._Ready();

        CallDeferred("CustomSetup");
    }

    public void CustomSetup() {
        var map = NavigationServer3D.MapCreate();
        NavigationServer3D.MapSetUp(map, Vector3.Up);
        NavigationServer3D.MapSetActive(map, true);

        var region = NavigationServer3D.RegionCreate();
        NavigationServer3D.RegionSetTransform(region, new Transform3D());
        NavigationServer3D.RegionSetMap(region, map);

        var newNavMesh = new NavigationMesh();

        List<Vector3> vectors = new List<Vector3>() {
            new Vector3(0, 0, 0),
            new Vector3(9.0f, 0, 0),
            new Vector3(0, 0, 9.0f),
        };
    }
}
