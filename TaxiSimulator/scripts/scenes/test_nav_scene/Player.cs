using System;
using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;

public partial class Player : CharacterBody3D {
	
	private NavigationAgent3D _agent;
	private Random _rand = new();
	private TestCamera camera;
	private MeshInstance3D _line;

	public override async void _Ready() {
		base._Ready();

		_agent = GetNode<NavigationAgent3D>("NavigationAgent3D");
		camera = GetParent().GetNode<TestCamera>("Camera3D");

		SetPhysicsProcess(false);
		await ToSignal(GetTree(), "physics_frame");
		SetPhysicsProcess(true);

		CallDeferred("CustomSetup");
	}

	private async void CustomSetup() {
		await ToSignal(GetTree(), "physics_frame");
		var path = NavigationServer3D.MapGetPath(_agent.GetNavigationMap(), GlobalPosition, _agent.TargetPosition, true);
		
		var meshInstance = new MeshInstance3D();
		var immedMesh = new ImmediateMesh();
		var material = new OrmMaterial3D();

		meshInstance.Mesh = immedMesh;
		meshInstance.CastShadow = GeometryInstance3D.ShadowCastingSetting.Off;

		immedMesh.SurfaceBegin(Mesh.PrimitiveType.LineStrip, material);
		foreach (var v in path) {
			immedMesh.SurfaceAddVertex(v);
		}
		immedMesh.SurfaceEnd();

		material.ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded;
		material.AlbedoColor = Colors.Red;

		_line?.QueueFree();
		_line = meshInstance;
		GetTree().Root.AddChild(_line);
	}

	public override void _UnhandledInput(InputEvent @event) {
		base._UnhandledInput(@event);

		if (@event.IsActionPressed(InputActionDictionary.LeftClick)) {
			_agent.TargetPosition = camera.TargetPoint;
			CallDeferred("CustomSetup");			
		}
	}

	public override void _PhysicsProcess(double delta) {
		base._PhysicsProcess(delta);
	}
}
