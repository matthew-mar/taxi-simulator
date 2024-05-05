using Godot;
using TaxiSimulator.Common.Contracts.Processes;
using TaxiSimulator.Services.Process;

namespace TaxiSimulator.Scenes.OrderCard.View {
    public partial class CompanyIcon : TextureRect {
        public const string NodePath = "base_panel/icon_panel/icon";

        public void SetIcon(string iconPath) {
            var loadIconProcess = new LoadImage(iconPath);
            loadIconProcess.Completed += (ProcessResult result) => {
                if (result is LoadImageResult loadImageResult) {
                    Texture = loadImageResult.Texture;
                }
            };
            ProcessService.Instance.AddProcess(loadIconProcess);
        }
    }
}
