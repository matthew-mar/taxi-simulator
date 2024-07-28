using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class ObjectRepository : BaseRepository, IObjectRepository {
        public ObjectRepository(DbProvider dbProvider) : base(dbProvider) {
        }
    }
}
