using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class OrderRepository : BaseRepository, IOrderRespository {
        public OrderRepository(DbProvider dbProvider) : base(dbProvider) { }
    }
}
