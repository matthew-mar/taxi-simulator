using TaxiSimulator.Services.Process;
using TaxiSimulator.Services.Db.Processes;

using Godot;
using DbPackage;
using System.IO;

namespace TaxiSimulator.Services.Db {
    public partial class DbService : Node {
        public static DbService Instance { get; private set; }

        public DbProvider DbProvider { get; private set; }

        private static string DbPath 
            => ProjectSettings.GlobalizePath(TsDbContextFactory.DbFileName);

        public override void _Ready() {
            base._Ready();

            Instance ??= this;

            DbProvider = new DbProvider(DbPath);
            if (! File.Exists(DbPath)) {
                var migrate = new Migrate();
                migrate.Completed += () => {
                    GD.Print("Db migrated");
                };
                ProcessService.Instance.AddProcess(migrate);
            }
        }
    }
}
