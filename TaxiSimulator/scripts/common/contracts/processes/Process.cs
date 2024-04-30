using System.Threading.Tasks;

namespace TaxiSimulator.Common.Contracts.Processes {
    public interface IProcess {
        public delegate void ProcessEventHandler();

        public event ProcessEventHandler Completed;

        Task RunAsync();
    }
}
