namespace DbPackage.Repositories {
    public abstract class BaseRepository {
        protected DbProvider _dbProvider;

        public BaseRepository(DbProvider dbProvider) {
            _dbProvider = dbProvider;
        }
    }
}
