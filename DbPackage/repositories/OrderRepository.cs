using DbPackage.Contracts;
using DbPackage.Models;
using DbPackage.Structures;
using Microsoft.EntityFrameworkCore;

namespace DbPackage.Repositories {
    public class OrderRepository : BaseRepository, IOrderRespository {
        public OrderRepository(DbProvider dbProvider) : base(dbProvider) { }

        public async Task<int> CountByCompletedStatusAsync(bool completed) {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return await _dbProvider.Context.Orders.CountAsync(
                order => 
                    completed 
                        ? order.CompletedAt != null 
                        : order.CompletedAt == null
                    && 
                        order.TakenAt == null
            );
        }

        public IQueryable<MarkCount> CountByMarks() {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return _dbProvider.Context.Orders
                .Where(order => order.CompletedAt != null)
                .GroupBy(order => order.Mark)
                .Select(order => new MarkCount { Mark = order.Key, Count = order.Count() });
        }

        public async Task<List<Order>> PaginateOrdersAsync(int offset) {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return await _dbProvider.Context.Orders
                .Where(
                    order => 
                        order.TakenAt == null
                        && order.CompletedAt == null
                )
                .OrderBy(order => order.CreatedAt)
                .Skip(offset * IOrderRespository.OrderPageCount)
                .Take(IOrderRespository.OrderPageCount)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id) {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            return await _dbProvider.Context.Orders
                .Where(order => order.Id == id)
                .FirstAsync();
        }

        public async Task UpdateByModelAsync(Order order) {
            if (_dbProvider.Context.Orders == null) {
                throw new Exception("orders table doesn't exist");
            }
            _dbProvider.Context.Orders.Update(order);
            await _dbProvider.Context.SaveChangesAsync();
        }
    }
}
