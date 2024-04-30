using System;
using System.Collections.Generic;
using Godot;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Services.Process {
    public partial class ProcessService : Node {
        public static ProcessService Instance { get; private set; }

        private delegate void ProcessEventHandler();

        private event ProcessEventHandler ProcessAdded;

        private Queue<IProcess> _processes = new();

        private bool _isRunning = false;

        public override void _Ready() {
            base._Ready();

            Instance ??= this;

            ProcessAdded += RunProcesses;
        }

        public void AddProcess(IProcess process) {
            _processes.Enqueue(process);
            if (_isRunning) {
                return;
            }
            ProcessAdded.Invoke();
        }

        private async void RunProcesses() {
            _isRunning = true;
            while (_processes.Count > 0) {
                IProcess process = _processes.Dequeue();
                try {
                    await process.RunAsync();
                } catch (Exception ex) {
                    GD.Print($"Background process failed {ex.Message}");
                }
            }
            _isRunning = false;
        }
    }
}
