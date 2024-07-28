using System.Threading.Tasks;
using Godot;
using TaxiSimulator.Common.Contracts.Processes;

namespace TaxiSimulator.Services.Process {
    public class LoadImageResult : ProcessResult {
        public Texture2D Texture { get; set; }
    }

    public class LoadImage : IProcess {
        public event IProcess.ProcessEventHandler Completed;

        private string _imagePath;

        public ProcessResult Result { get; private set;}

        public LoadImage(string imagePath) {
            _imagePath = imagePath;
        }

        public async Task RunAsync() {
            await Task.Run(() => {
                var texture = GD.Load<Texture2D>(_imagePath);
                if (texture != null) {
                    Completed.Invoke(new LoadImageResult() {
                        Texture = texture,
                    });
                } else {
                    GD.Print($"Failed load image: {_imagePath}");
                }
            });
        }
    }
}
