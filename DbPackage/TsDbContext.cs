using System.Text.Json;
using DbPackage.Models;
using DbPackage.Structures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DbPackage {
    public class TsDbContext : DbContext {
        private string _dbPath;

        public TsDbContext(string dbPath) {
            _dbPath = dbPath;            
        }

        public DbSet<Company>? Companies { get; set; }

        public DbSet<Models.Object>? Objects { get; set; }

        public DbSet<ObjectType>? ObjectTypes { get; set; }

        public DbSet<Order>? Orders { get; set; }

        public DbSet<Player>? Players { get; set; }

        public DbSet<Transaction>? Transactions { get; set; }

        public DbSet<TransactionType>? TransactionTypes { get; set; }

        public async Task MakeMigrationsAsync() => await Database.MigrateAsync();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
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

    public class TsDbContextFactory : IDesignTimeDbContextFactory<TsDbContext> {
        public const string DbFileName = "user://ts.db";

        public TsDbContext CreateDbContext(string[] args) => new(DbFileName);
    }
}
