using DbPackage.Contracts;
using DbPackage.Structures;
using Microsoft.EntityFrameworkCore;

namespace DbPackage.Repositories {
    public class OrderRepository : BaseRepository, IOrderRespository {
        public OrderRepository(DbProvider dbProvider) : base(dbProvider) { }

        public async Task<int> CountByCompletedStatusAsync(bool completed) {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return await _dbProvider.Context.Orders.CountAsync(order => completed 
                ? order.CompletedAt != null 
                : order.CompletedAt == null
            );
        }

        public IQueryable<MarkCount> CountByMarks()
        {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return _dbProvider.Context.Orders
                .Where(order => order.CompletedAt != null)
                .GroupBy(order => order.Mark)
                .Select(order => new MarkCount { Mark = order.Key, Count = order.Count() });
        }
    }
}
