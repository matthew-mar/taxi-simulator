using TaxiSimulatorDb.Structures;
using TaxiSimulatorDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Text.Json;

namespace TaxiSimulatorDb {
    public class TaxiSimulatorDbContextFactory : IDesignTimeDbContextFactory<TaxiSimulatorDbContext> {
        public const string DatabaseFileName = "user://taxi_simulator.db";
        
        public TaxiSimulatorDbContext CreateDbContext(string[] args) {
            return new TaxiSimulatorDbContext(DatabaseFileName);            
        }
    }

    public class TaxiSimulatorDbContext : DbContext {
        public DbSet<Order>? Orders { get; set; }

        public async Task MakeMigrationsAsync() => await Database.MigrateAsync();

        private string _databaseFilePath;

        public TaxiSimulatorDbContext(string databasePath) {
            _databaseFilePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={_databaseFilePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Order>()
                .Property(e => e.DeparturePoint)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<DbVector?>(v, (JsonSerializerOptions?)null)
                );

            modelBuilder
                .Entity<Order>()
                .Property(e => e.DestinationPoint)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<DbVector?>(v, (JsonSerializerOptions?)null)
                );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
