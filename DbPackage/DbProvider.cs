using DbPackage.Contracts;
using DbPackage.Repositories;

namespace DbPackage {
    public class DbProvider {
        private TsDbContext? _context = null;

        private ICompanyRepository? _companyRepository = null;

        private IObjectRepository? _objectRepository = null; 

        private IObjectTypeRepository? _objectTypeRepository = null;

        private IOrderRespository? _orderRespository = null;

        private IPlayerRepository? _playerRepository = null;

        private ITarifPlanRepository? _tarifPlanRepository = null;

        private ITransactionRepository? _transactionRepository = null;

        private ITransactionTypeRepository? _transactionTypeRepository = null;

        private string _dbPath;

        public TsDbContext Context {
            get {
                _context ??= new(_dbPath);
                return _context;
            }
        }

        public DbProvider(string dbPath) {
            _dbPath = dbPath;
        }

        public ICompanyRepository CompanyRepository {
            get {
                _companyRepository ??= new CompanyRepository(this);
                return _companyRepository;
            }
        }

        public IObjectRepository ObjectRepository {
            get {
                _objectRepository ??= new ObjectRepository(this);
                return _objectRepository;
            }
        }

        public IObjectTypeRepository ObjectTypeRepository {
            get {
                _objectTypeRepository ??= new ObjectTypeRepository(this);
                return _objectTypeRepository;
            }
        }

        public IOrderRespository OrderRespository {
            get {
                _orderRespository ??= new OrderRepository(this);
                return _orderRespository;
            }
        }

        public IPlayerRepository PlayerRepository {
            get {
                _playerRepository ??= new PlayerRepository(this);
                return _playerRepository; 
            }
        }

        public ITarifPlanRepository TarifPlanRepository {
            get {
                _tarifPlanRepository ??= new TarifPlanRepository(this);
                return _tarifPlanRepository;
            }
        }

        public ITransactionRepository TransactionRepository {
            get {
                _transactionRepository ??= new TransactionRepository(this);
                return _transactionRepository;
            }
        }

        public ITransactionTypeRepository TransactionTypeRepository {
            get {
                _transactionTypeRepository ??= new TransactionTypeRepository(this);
                return _transactionTypeRepository;
            }
        }
    }
}
