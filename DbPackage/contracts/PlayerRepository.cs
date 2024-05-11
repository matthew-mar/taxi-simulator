using DbPackage.Models;

namespace DbPackage.Contracts {
    public interface IPlayerRepository {
        Task CreatePlayerAsync();

        Task<Player> GetFirstAsync();

        Task UpdateByModelAsync(Player player);
    }
}
