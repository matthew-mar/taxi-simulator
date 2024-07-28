using DbPackage.Models;
using DbPackage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DbPackage.Repositories {
    public class CompanyRepository : BaseRepository, ICompanyRepository {
        public CompanyRepository(DbProvider dbProvider) : base(dbProvider) { }

        public async Task<Company> GetByIdAsync(int id) {
            if (_dbProvider.Context.Companies == null) {
                throw new Exception("companies table doesn't exist");
            }
            return await _dbProvider.Context.Companies
                .Where(company => company.Id == id)
                .FirstAsync();
        }

        public async Task CreateManyCompaniesAsync(List<Company> companies) {
            if (_dbProvider.Context.Companies == null) {
                throw new Exception("companies table doesn't exist");
            }
            await _dbProvider.Context.Companies.AddRangeAsync(companies);
            await _dbProvider.Context.SaveChangesAsync();
        }
    }
}
