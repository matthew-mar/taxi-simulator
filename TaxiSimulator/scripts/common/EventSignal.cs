using System;
using Godot;

namespace TaxiSimulator.Common {

    public partial class EventSignalArgs : GodotObject {}

    public abstract partial class EventSignal : GodotObject {
        protected abstract string EventName { get; }

        public void Emit(EventSignalArgs signalArgs = null) {
            EmitSignal(EventName, signalArgs);   
        }

        public void Attach(Callable callable) {
            Connect(EventName, callable);
        }

        public void Detach(Callable callable) {
            Disconnect(EventName, callable);
        }
    }
}
