using System;
using System.Collections.Generic;

using Godot;

namespace TaxiSimulator.Scenes.PathFinder.View {
    public partial class PathAgent : NavigationAgent3D {
        public const string NodePath = "PathAgent";

        private Vector3 _fromPosition;

        private List<MeshInstance3D> _lines = new();

        public void DrawPathOnScene(Vector3[] path, Window sceneRoot) {
            GD.Print("Draw");
            ClearLines();
            for (int i = 0; i < path.Length - 1; i++) {
                var line = DrawCylinderLine(path[i], path[i + 1]);
                sceneRoot.AddChild(line);
                _lines.Add(line);
            }
            GD.Print(_lines.Count);
        }

        public override void _Process(double delta) {
            base._Process(delta);
        }

        public void ClearLines() {
            GD.Print("clear");
            foreach (var line in _lines) {
                line.QueueFree();
            }
            _lines.Clear();
        }

        private static MeshInstance3D DrawCylinderLine(Vector3 start, Vector3 end) {
            var meshInstance = new MeshInstance3D() {
                Mesh = new CylinderMesh() {
                    TopRadius = 3f,
                    BottomRadius = 3f,
                    Height = (end - start).Length(),
                    RadialSegments = 12, 
                },
                Transform = Transform3D.Identity,
                CastShadow = GeometryInstance3D.ShadowCastingSetting.Off,
                Layers = 1 << 1,
            };
            
            Vector3 dir = (end - start).Normalized();
            Vector3 rotAxis = Vector3.Up.Cross(dir);
            float angle = (float)Math.Acos(Vector3.Up.Dot(dir));
            
            meshInstance.Transform = new Transform3D(
                new Basis(rotAxis, angle), 
                start + (end - start) * 0.5f
            );

            var material = new OrmMaterial3D() {
                ShadingMode = BaseMaterial3D.ShadingModeEnum.Unshaded,
                AlbedoColor = Colors.Red,
            };
            
            meshInstance.SetSurfaceOverrideMaterial(0, material);

            return meshInstance;
        }
    }
}
