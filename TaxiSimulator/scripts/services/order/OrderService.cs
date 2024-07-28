using Godot;
using TaxiSimulator.Services.Process;
using TaxiSimulator.Services.Order.Signals;
using TaxiSimulator.Services.Order.Processes;
using TaxiSimulator.Common.Contracts.Processes;
using GameSignals = TaxiSimulator.Scenes.GameScene.Signals;

namespace TaxiSimulator.Services.Order {
	public partial class OrderService : Node {
		public static OrderService Instance { get; private set; }

		public override void _Ready() {
			base._Ready();
			Instance ??= this;
		}

		public void Attach() {

		}

		public void Detach() {

		}

		public void LoadOrders(int offset) {
			var loadOrdersProcess = new LoadOrders(offset);
			loadOrdersProcess.Completed += (ProcessResult res) => {
				if (res is OrdersResult ordersRes) {
					SignalsProvider.OrdersLoadedSignal.Emit(new OrdersArgs() {
						Orders = ordersRes.Orders,
					});
				}
			};
			ProcessService.Instance.AddProcess(loadOrdersProcess);
		}

		// public async Task<List<ModelOrder>> GetOrders(int offset)
		//     => await DbService.Instance
		//         .DbProvider
		//         .OrderRespository
		//         .PaginateOrdersAsync(offset);
	}
}
