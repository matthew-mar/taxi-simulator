using DbPackage.Contracts;

namespace DbPackage.Repositories {
    public class CompanyRepository : BaseRepository, ICompanyRepository {
        public CompanyRepository(DbProvider dbProvider) : base(dbProvider) { }
    }
}
