using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class PlayerRepository : BaseRepository, IPlayerRepository {
        public PlayerRepository(DbProvider dbProvider) : base(dbProvider) {}
    }
}
