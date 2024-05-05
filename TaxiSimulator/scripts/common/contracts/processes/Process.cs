using System;
using System.Threading.Tasks;

namespace TaxiSimulator.Common.Contracts.Processes {
    #nullable enable
    public abstract class ProcessResult {}

    public interface IProcess {

        public delegate void ProcessEventHandler(ProcessResult? result);

        public event ProcessEventHandler Completed;

        Task RunAsync();
    }
}
