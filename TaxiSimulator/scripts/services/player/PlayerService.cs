using Godot;
using TaxiSimulator.Services.Db;
using ModelPayer = DbPackage.Models.Player;
using TaxiSimulator.Services.Player.Signals;
using DbSignals = TaxiSimulator.Services.Db.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Signals;
using TaxiSimulator.Common;

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

		private ModelPayer? _player;

		public override void _Ready() {
			base._EnterTree(); 

			Instance ??= this;

			DbSignals.SignalsProvider.DatabaseInitializedSignal.DatabaseInitialized +=
				async (EventSignalArgs args) => {
					_player = await DbService.Instance.DbProvider.PlayerRepository.GetFirstAsync();
				};

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
			SendExperience();
			SendBalance();
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

		private void SendExperience() => SignalsProvider.ExperienceSignal.Emit(
			new ExperienceArgs() {
				Experience = _player?.Experience ?? 0f,
			}
		);

		private void SendBalance() => SignalsProvider.BalanceSignal.Emit(new BalanceArgs() {
			Balance = _player?.Balance ?? 0f,
		});
	}
}
