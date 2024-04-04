extends Node3D

func _ready():
	# use call deferred to make sure the entire scene tree nodes are setup
	# else await / yield on 'physics_frame' in a _ready() might get stuck
	set_physics_process(false)
	await get_tree().physics_frame
	set_physics_process(true)
	call_deferred("custom_setup")

func custom_setup():

	# create a new navigation map
	var map: RID = NavigationServer3D.map_create()
	NavigationServer3D.map_set_up(map, Vector3.UP)
	NavigationServer3D.map_set_active(map, true)

	# create a new navigation region and add it to the map
	var region: RID = NavigationServer3D.region_create()
	NavigationServer3D.region_set_transform(region, Transform3D())
	NavigationServer3D.region_set_map(region, map)

	# create a procedural navigation mesh for the region
	var new_navigation_mesh: NavigationMesh = NavigationMesh.new()
	var vertices: PackedVector3Array = PackedVector3Array([
		Vector3(0,0,0),
		Vector3(9.0,0,0),
		Vector3(0,0,9.0)
	])
	new_navigation_mesh.set_vertices(vertices)
	var polygon: PackedInt32Array = PackedInt32Array([0, 1, 2])
	new_navigation_mesh.add_polygon(polygon)
	NavigationServer3D.region_set_navigation_mesh(region, new_navigation_mesh)

	# wait for NavigationServer sync to adapt to made changes
	await get_tree().physics_frame

	# query the path from the navigationserver
	var start_position: Vector3 = Vector3(0.1, 0.0, 0.1)
	var target_position: Vector3 = Vector3(1.0, 0.0, 1.0)
	var optimize_path: bool = true

	var path: PackedVector3Array = NavigationServer3D.map_get_path(
		map,
		start_position,
		target_position,
		optimize_path
	)

	print("Found a path!")
	print(path)
