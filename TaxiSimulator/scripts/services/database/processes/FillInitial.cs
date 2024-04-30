using System.Threading.Tasks;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Services.Db.Processes {
    public class FillInitial : IProcess {
        public event IProcess.ProcessEventHandler Completed;

        public async Task RunAsync() {
            await DbService.Instance.DbProvider.PlayerRepository.CreatePlayerAsync();
            Completed?.Invoke();
        }
    }
}
