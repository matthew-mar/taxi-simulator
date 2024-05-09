using Godot;
using TaxiSimulator.Services.Process;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Scenes.OrderCard.View {
    public partial class CompanyIcon : TextureRect {
        public const string NodePath = "base_panel/icon_panel/icon";

        public void SetIcon(string iconPath) {
            var loadIconProcess = new LoadImage(iconPath);
            loadIconProcess.Completed += (ProcessResult result) => {
                if (result is LoadImageResult loadImageResult) {
                    CallDeferred(nameof(SetTexture), loadImageResult.Texture);
                }
            };
            ProcessService.Instance.AddProcess(loadIconProcess);
        }

        private void SetTexture(Texture2D texture) => Texture = texture;
    }
}
