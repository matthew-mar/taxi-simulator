using System.Threading.Tasks;
using TaxiSimulator.Services.Db;
using System.Collections.Generic;
using ModelOrder = DbPackage.Models.Order;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Services.Order.Processes {
    public class OrdersResult : ProcessResult {
        public List<ModelOrder> Orders { get; set; }
    }

    public class LoadOrders : IProcess {
        public event IProcess.ProcessEventHandler Completed;

        private int _offset;

        public LoadOrders(int offset) {
            _offset = offset;
        }

        public Task RunAsync() {
            return Task.Run(async () => {
                var orders = await DbService.Instance
                    .DbProvider
                    .OrderRespository
                    .PaginateOrdersAsync(_offset);
            
                Completed?.Invoke(new OrdersResult() {
                    Orders = orders
                });
            });
        }
    }
}
