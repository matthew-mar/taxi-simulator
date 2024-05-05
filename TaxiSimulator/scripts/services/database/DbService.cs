using TaxiSimulator.Services.Process;
using TaxiSimulator.Services.Db.Processes;

using Godot;
using DbPackage;
using System.IO;
using TaxiSimulator.Services.Db.Signals;
using TaxiSimulator.Common.Contracts.Processes;

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
				migrate.Completed += (ProcessResult? result) => {
					GD.Print("Db migrated");
					FillDbInitial();
				};
				ProcessService.Instance.AddProcess(migrate);
				return;
			}
			SignalsProvider.DatabaseInitializedSignal.Emit();
		}

		private static void FillDbInitial() {
			var fillInitial = new FillInitial();
			fillInitial.Completed += (ProcessResult? result) => {
				GD.Print("Initial fill completed");
				SignalsProvider.DatabaseInitializedSignal.Emit();
			};
			ProcessService.Instance.AddProcess(fillInitial);
		}
	}
}
