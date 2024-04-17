using TaxiSumulatorDb.Models;
using Microsoft.EntityFrameworkCore;

namespace TaxiSumulatorDb {
    public class TaxiSumulatorDbContext : DbContext {
        public DbSet<Order>? Orders { get; set; }

        public const string DatabaseFileName = "user://taxi_simulator.db";

        public async Task MakeMigrationsAsync() => await Database.MigrateAsync();

        private string _databaseFilePath;

        public TaxiSumulatorDbContext(string databasePath) {
            _databaseFilePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={_databaseFilePath}");
        }
    }
}
