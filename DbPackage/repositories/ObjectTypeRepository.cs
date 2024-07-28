using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class ObjectTypeRepository : BaseRepository, IObjectTypeRepository {
        public ObjectTypeRepository(DbProvider dbProvider) : base(dbProvider) {}
    }
}
