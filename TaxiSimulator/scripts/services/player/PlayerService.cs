using Godot;
using TaxiSimulator.Services.Player.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Singlas;

namespace TaxiSimulator.Services.Player {
    #nullable enable
    public partial class PlayerService : Node {
        private const int SleepInterval = 500;

        public static PlayerService? Instance { get; private set; }

        private static double TirednessFactor {
			get {
				var tirednessPerSecond = 100.0 / SleepInterval;
				var framesCount = Engine.GetFramesPerSecond();
				var tirednessPerFrame = tirednessPerSecond / framesCount;
				return tirednessPerFrame;
			}
		}

        public bool Tired => _tiredness <= 0f;

        private double _tiredness = 100.0;

        private Vector3 _restPoint;

        public override void _Ready() {
            base._EnterTree(); 

            Instance ??= this;

            ParkingSignals.SignalsProvider.RestAllowedSignal.Attach(
                Callable.From((ParkingSignals.RestAllowedArgs args) => {
					if (! args.Allowed) {
						return;
					}

					Rest();
					_restPoint = args.ParkingPosition;
				})
            );
        }

        public override void _Process(double delta) {
            base._Process(delta);

            DecreaseTiredness();
            SendTiredness();
        }

        private void DecreaseTiredness() {
            if (Tired) {
                return;
            }
            _tiredness -= TirednessFactor;
        }

        private void SendTiredness() => SignalsProvider.TiredSignal.Emit(new TirednessArgs() {
            Tiredness = _tiredness,
        });

        private void Rest() {
            _tiredness = 100.0;
            SignalsProvider.RestSignal.Emit(new RestArgs() {
                RestPoint = _restPoint,
            });
        }
    }
}
