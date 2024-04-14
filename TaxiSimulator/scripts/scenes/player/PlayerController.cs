using Godot;
using System;
using TaxiSimulator.Common;
using TaxiSimulator.Scenes.Player.Signals;
using CarSignals = TaxiSimulator.Scenes.CarScene.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Singlas;

namespace TaxiSimulator.Scenes.Player {
	public partial class PlayerController : Node {
		private const int SleepInterval = 50;
		
		public static PlayerController Instance;
		
		private static long NowTimeStamp => ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

		private static double TirednessFactor {
			get {
				var tirednessPerSecond = 100f / SleepInterval;
				var framesCount = Engine.GetFramesPerSecond();
				var tirednessPerFrame = tirednessPerSecond / framesCount;
				return tirednessPerFrame;
			}
		}

		private double _tiredNess = 100f;

		private long _lastTimeSleep;

		public bool Tired => _tiredNess <= 0f;

		private Vector3 _restPoint;

		public override void _Ready() {
			base._Ready();

			Instance ??= this;
			_lastTimeSleep = NowTimeStamp;

			CarSignals.SignalsProvider.RespawnedSignal.Respawned += (EventSignalArgs args) => {
				RefreshTiredness();
			};

			ParkingSignals.SignalsProvider.RestAllowedSignal.RestAllowed += 
				(ParkingSignals.RestAllowedArgs args) => {
					if (! args.Allowed) {
						return;
					}

					RefreshTiredness();
					_restPoint = args.ParkingPosition;
				};
		}

		public override void _Process(double delta) {
			base._Process(delta);

			CheckTiredness();
			SendTiredness();
		}

		private void CheckTiredness() {
			if (Tired) {
				return;
			}

			_tiredNess -= TirednessFactor;
		}

		private void SendTiredness() {
			SignalsProvider.TiredSignal.Emit(new TirednessArgs() {
				Tiredness = _tiredNess,
			});
		}

		private void RefreshTiredness() {
			_tiredNess = 100f;
			SignalsProvider.RestSignal.Emit(new RestArgs() {
				RestPoint = _restPoint,
			});
		}
	}
}
