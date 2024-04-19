namespace TaxiSimulatorDb.Repositories {
    public abstract class BaseRepository {
        protected TaxiSimulatorDbProvider _dbProvider;

        public BaseRepository(TaxiSimulatorDbProvider dbProvider) {
            _dbProvider = dbProvider;
        }
    }
}
