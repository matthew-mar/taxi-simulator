using DbPackage.Models;
using DbPackage.Structures;

namespace DbPackage.Contracts {
    public interface IOrderRespository {
        const int OrderPageCount = 3;

        Task<int> CountByCompletedStatusAsync(bool completed);

        IQueryable<MarkCount> CountByMarks();

        Task<List<Order>> PaginateOrdersAsync(int offset);

        Task<Order> GetOrderByIdAsync(int id);
    }
}
