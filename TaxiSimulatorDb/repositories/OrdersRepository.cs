using TaxiSimulatorDb.Models;
using TaxiSimulatorDb.Contracts;

namespace TaxiSimulatorDb.Repositories {
    public class OrdersRepository : BaseRepository, IOrdersRepository {
        public OrdersRepository(TaxiSimulatorDbProvider dbProvider) : base(dbProvider) { }

        public async Task<Order> Add(Order order) {
            if (_dbProvider.Context.Orders == null) {
                throw new NullReferenceException("No orders table");
            }
            await _dbProvider.Context.Orders.AddAsync(order);
            await _dbProvider.Context.SaveChangesAsync();
            return order;
        }
    }
}
