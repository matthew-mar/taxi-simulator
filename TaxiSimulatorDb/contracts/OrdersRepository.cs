using TaxiSimulatorDb.Models;

namespace TaxiSimulatorDb.Contracts {
    public interface IOrdersRepository {
        Task<Order> Add(Order order);
    }
}
