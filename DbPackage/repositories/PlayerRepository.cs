using DbPackage.Models;
using DbPackage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DbPackage.Repositories {
    public class PlayerRepository : BaseRepository, IPlayerRepository {
        public PlayerRepository(DbProvider dbProvider) : base(dbProvider) {}

        public async Task CreatePlayerAsync() {
            var player = new Player() {
                Balance = 0f,
                Experience = 0f,
            };
            if (_dbProvider.Context.Players == null) {
                throw new Exception("players table doesn't exist");
            }
            await _dbProvider.Context.Players.AddAsync(player);
            await _dbProvider.Context.SaveChangesAsync();
        }

        public async Task<Player> GetFirstAsync() {
            if (_dbProvider.Context.Players == null) {
                throw new Exception("players table doesn't exist");
            }
            return await _dbProvider.Context.Players.Where(player => player.Id == 1).FirstAsync();
        }

        public async Task UpdateByModelAsync(Player player) {
            if (_dbProvider.Context.Players == null) {
                throw new Exception("players table doesn't exist");
            }
            _dbProvider.Context.Players.Update(player);
            await _dbProvider.Context.SaveChangesAsync();
        }
    }
}
