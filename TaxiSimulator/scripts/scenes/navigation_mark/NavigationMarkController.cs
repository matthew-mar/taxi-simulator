using TaxiSimulator.Common;
using TaxiSimulator.Scenes.NavigationMark.View;
using TaxiSimulator.Scenes.NavigationMark.Signals;

using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;
using MapCameraSignals = TaxiSimulator.Scenes.MapCameraScene.Signals;

using Godot;
using System;
using TaxiSimulator.Services.Db;
using TaxiSimulator.Common.Helpers;

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
				})
			);

			MapCameraSignals.SignalsProvider.PointCleanedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					_destinationPoint = null;
					SignalsProvider.DestinationDestroyedSignal.Emit();
				})
			);

			CarSignals.SignalsProvider.PositionChangedSignal.Attach(
				Callable.From((CarSignals.PositionSignalArgs args) => {
					if (_destinationPoint == null) {
						return;
					}

					_markAgent.FindPath(
						GlobalPosition, 
						_destinationPoint ?? throw new ArgumentNullException(
							"Destination Point can not be null"
						)
					);
				})
			);

			OrderSignals.SignalsProvider.OrderSelectedSignal.OrderSelected += 
				async (OrderSignals.OrderSelectedArgs args) => {
					GD.Print("order selected draw path");

					var order = await DbService.Instance.DbProvider
						.OrderRespository
						.GetOrderByIdAsync(args.OrderId);

					GD.Print(order.DepartureName);
					
					_markAgent.FindPath(
						VectorConverter.FromDb(order.DeparturePoint),
						VectorConverter.FromDb(order.DestinationPoint)
					);
				};
		}

		public override void _Process(double delta) {
			base._Process(delta);

			_markAgent.CheckPointReach();
		}
	}
}
