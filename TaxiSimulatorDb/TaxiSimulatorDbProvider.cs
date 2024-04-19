using TaxiSimulatorDb.Contracts;
using TaxiSimulatorDb.Repositories;

namespace TaxiSimulatorDb {
    public class TaxiSimulatorDbProvider {
        private TaxiSimulatorDbContext? _context = null;

        private IOrdersRepository? _ordersRepository = null;

        private string _databasePath;

        public TaxiSimulatorDbContext Context {
            get {
                _context ??= new(_databasePath);
                return _context;
            }
        }

        public IOrdersRepository OrdersRepository {
            get {
                _ordersRepository ??= new OrdersRepository(this);
                return _ordersRepository;
            }
        }

        public TaxiSimulatorDbProvider(string databasePath) {
            _databasePath = databasePath;            
        }
    }
}
