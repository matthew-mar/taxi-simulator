using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class TransactionRepository : BaseRepository, ITransactionRepository {
        public TransactionRepository(DbProvider dbProvider) : base(dbProvider) { }
    }
}
