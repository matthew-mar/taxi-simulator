using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class TransactionTypeRepository : BaseRepository, ITransactionTypeRepository {
        public TransactionTypeRepository(DbProvider dbProvider) : base(dbProvider) { }
    }
}
