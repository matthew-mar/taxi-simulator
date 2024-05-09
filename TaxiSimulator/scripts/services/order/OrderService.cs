using Godot;
using System.Threading.Tasks;
using TaxiSimulator.Services.Db;
using System.Collections.Generic;
using ModelOrder = DbPackage.Models.Order;

namespace TaxiSimulator.Services.Order {
    public partial class OrderService : Node {
        public static OrderService Instance { get; private set; }

        public override void _Ready() {
            base._Ready();
            Instance ??= this;
        }

        public async Task<List<ModelOrder>> GetOrders(int offset)
            => await DbService.Instance
                .DbProvider
                .OrderRespository
                .PaginateOrdersAsync(offset);
    }
}
