using TaxiSimulator.Services.Db;
using TaxiSimulator.Services.Game;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.OrderGridCameraScene.View;
using TaxiSimulator.Common.Scenes.MoveableCameraScene;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;
using Godot;
using TaxiSimulator.Common;

namespace TaxiSimulator.Scenes.OrderGridCameraScene {
	public partial class OrderGridCameraController : MoveableCameraController {
		protected override bool Active => GameService.Instance.GameMode == GameScene.GameMode.OrderGrid;

		private OrderGridCamera _gridCamera;

		public override void _Ready() {
			base._Ready();

			_gridCamera = (OrderGridCamera)_camera;

			OrderSignals.SignalsProvider.OrderSelectedSignal.OrderSelected +=
				async (OrderSignals.OrderArgs args) => {
					var order = await DbService.Instance.DbProvider
						.OrderRespository
						.GetOrderByIdAsync(args.OrderId);

					_gridCamera.BlitFlags(
						VectorConverter.FromDb(order.DeparturePoint),
						VectorConverter.FromDb(order.DestinationPoint)
					);
				};

			OrderSignals.SignalsProvider.OrderTakenSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					_gridCamera.ClearFlags();
				})
			);
		}
	}
}
