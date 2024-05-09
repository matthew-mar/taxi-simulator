using DbPackage.Models;

namespace DbPackage.Contracts {
    public interface ICompanyRepository {
        Task<Company> GetByIdAsync(int id);

        Task CreateManyCompaniesAsync(List<Company> companies);
    }
}
