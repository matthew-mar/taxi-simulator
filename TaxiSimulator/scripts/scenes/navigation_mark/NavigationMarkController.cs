using TaxiSimulator.Common;
using TaxiSimulator.Scenes.NavigationMark.View;
using TaxiSimulator.Scenes.NavigationMark.Signals;

using MapCameraSignals = TaxiSimulator.Scenes.MapCameraScene.Signals;
using OrderGridCameraSignals = TaxiSimulator.Scenes.OrderGridCameraScene.Signals;

using Godot;
using System;

namespace TaxiSimulator.Scenes.NavigationMark {
	public partial class NavigationMarkController : Sprite3D {
		private Vector3? _destinationPoint = null;

		private MarkAgent _markAgent;

		public async override void _Ready() {
			base._Ready();

			_markAgent = GetNode<MarkAgent>(MarkAgent.NodePath);

			SetPhysicsProcess(false);
			await ToSignal(GetTree(), "physics_frame");
			SetPhysicsProcess(true);

			MapCameraSignals.SignalsProvider.PointBlitedSignal.Attach(
				Callable.From((MapCameraSignals.PointBlitedArgs args) => {
					_destinationPoint = args.PointPosition;
					_markAgent.SetTarget(_destinationPoint ?? throw new ArgumentNullException(
							"Destination Point can not be null"
					));
					_markAgent.FindPath(
						GlobalPosition, 
						_destinationPoint ?? throw new ArgumentNullException(
							"Destination Point can not be null"
						)
					);
				})
			);

			MapCameraSignals.SignalsProvider.PointCleanedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					_destinationPoint = null;
					SignalsProvider.DestinationDestroyedSignal.Emit();
				})
			);

			OrderGridCameraSignals.SignalsProvider.FlagsBlitedSignal.Attach(
				Callable.From((OrderGridCameraSignals.FlagsBlitedArgs args) => {
					_markAgent.FindPath(args.DeparturePos, args.DestinationPos);
				})
			);
		}
	}
}
