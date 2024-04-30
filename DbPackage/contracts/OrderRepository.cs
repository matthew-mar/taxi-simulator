using DbPackage.Structures;

namespace DbPackage.Contracts {
    public interface IOrderRespository {
        Task<int> CountByCompletedStatusAsync(bool completed);

        IQueryable<MarkCount> CountByMarks();
    }
}
