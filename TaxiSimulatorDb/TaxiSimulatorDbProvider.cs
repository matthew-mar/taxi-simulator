namespace TaxiSumulatorDb {
    public class TaxiSimulatorDbProvider {
        private TaxiSumulatorDbContext? _context = null;

        private string _databasePath;

        public TaxiSumulatorDbContext Context {
            get {
                _context ??= new(_databasePath);
                return _context;
            }
        }

        public TaxiSimulatorDbProvider(string databasePath) {
            _databasePath = databasePath;            
        }
    }
}
