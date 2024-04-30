using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class TarifPlanRepository : BaseRepository, ITarifPlanRepository {
        public TarifPlanRepository(DbProvider dbProvider) : base(dbProvider) { }
    }
}
