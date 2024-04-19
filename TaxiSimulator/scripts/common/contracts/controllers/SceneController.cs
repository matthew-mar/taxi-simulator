using Godot;

namespace TaxiSimulator.Common.Contracts.Controllers {
    public interface ISceneController {
        void ClearSignals();

        Node GetNewNode();
    }
}
