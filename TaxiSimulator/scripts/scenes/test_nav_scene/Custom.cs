using Godot;

public partial class Custom : Node3D {
    public override async void _Ready() {
        base._Ready();

        SetPhysicsProcess(false);
        await ToSignal(GetTree(), "physics_frame");
        SetPhysicsProcess(true);

        CallDeferred("CustomSetup");
    }

    private async void CustomSetup()
    {
        var map = NavigationServer3D.MapCreate();
        NavigationServer3D.MapSetUp(map, Vector3.Up);
        NavigationServer3D.MapSetActive(map, true);

        var region = NavigationServer3D.RegionCreate();
        NavigationServer3D.RegionSetTransform(region, new Transform3D());
        NavigationServer3D.RegionSetMap(region, map);

        var newNavMesh = new NavigationMesh();
        var vert = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(9.0f, 0, 0),
            new Vector3(0, 0, 9.0f),
        };
        newNavMesh.Vertices = vert;
        var polygon = new int[] {0, 1, 2};
        newNavMesh.AddPolygon(polygon);
        NavigationServer3D.RegionSetNavigationMesh(region, newNavMesh);

        await ToSignal(GetTree(), "physics_frame");

        var startPos = new Vector3(.1f, .0f, .1f);
        var targetPos = new Vector3(1f, .0f, 1f);

        var path = NavigationServer3D.MapGetPath(map, startPos, targetPos, true);
        GD.Print(path);
    }
}
