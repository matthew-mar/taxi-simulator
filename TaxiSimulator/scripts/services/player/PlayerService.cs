using Godot;
using DbPackage.Structures;
using TaxiSimulator.Common;
using TaxiSimulator.Services.Db;
using TaxiSimulator.Common.Helpers;
using ModelOrder = DbPackage.Models.Order;
using ModelPayer = DbPackage.Models.Player;
using TaxiSimulator.Services.Player.Signals;
using DbSignals = TaxiSimulator.Services.Db.Signals;
using ParkingSignals = TaxiSimulator.Scenes.Parking.Signals;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;
using NavigationSignals = TaxiSimulator.Scenes.NavigationMark.Signals;
using System.Reflection;
using System;

namespace TaxiSimulator.Services.Player {
	public enum OrderWorkflowState {
		Free,
		Departure,
		Destination,
	}

	public class OrderWorkflow {
		private ModelOrder _order;

		private OrderWorkflowState _orderState;

		public OrderWorkflowState OrderState { 
			get => _orderState;
			set {
				_orderState = value;

				DbVector orderPoint = null;
				switch (value) {
					case OrderWorkflowState.Departure:
						orderPoint = _order.DeparturePoint;
						break;
					
					case OrderWorkflowState.Destination:
						orderPoint = _order.DestinationPoint;
						break;
					
					default:
						break;
				}

				if (orderPoint == null) {
					return;
				}

				SignalsProvider.WorkflowStateChangedSignal.Emit(new WorkflowStateArgs() {
					Point = VectorConverter.FromDb(orderPoint),
				});
			}
		}

		public OrderWorkflow() {
			_orderState = OrderWorkflowState.Free;
		}

		public async void TakeOrder(int orderId) {
			if (_order != null) {
				return;
			}
			_order = await DbService.Instance.DbProvider
				.OrderRespository
				.GetOrderByIdAsync(orderId);
			OrderState = OrderWorkflowState.Departure;
		}

		public float Price => _order.Price ?? 0f;

		public float PathLength => Mathf.Sqrt(
			Mathf.Pow(_order.DestinationPoint.X - _order.DeparturePoint.X, 2) +
			Mathf.Pow(_order.DestinationPoint.Y - _order.DeparturePoint.Y, 2) +
			Mathf.Pow(_order.DestinationPoint.Z - _order.DeparturePoint.Z, 2)
		);

		public async void Complete() {
			_order.CompletedAt = TimeTool.NowTimestamp;
			await DbService.Instance.DbProvider.OrderRespository.UpdateByModelAsync(_order);
			_order = null;
			OrderState = OrderWorkflowState.Free;
		}
	}

	#nullable enable
	public partial class PlayerService : Node {
		private const int SleepInterval = 5000;

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

		private OrderWorkflow _orderWorkflow = new();

		public override async void _Ready() {
			base._Ready();
			Instance ??= this;
			_player = await DbService.Instance.DbProvider.PlayerRepository.GetFirstAsync();
			Attach();	
		}

		public override void _Process(double delta) {
			base._Process(delta);
			DecreaseTiredness();
			SendTiredness();
			SendExperience();
			SendBalance();
		}

		public void Attach() {
			DbSignals.SignalsProvider.DatabaseInitializedSignal.DatabaseInitialized 
				+= OnDbInitialized;
			
			ParkingSignals.SignalsProvider.RestAllowedSignal.RestAllowed += OnRestAllowed;
			
			OrderSignals.SignalsProvider.OrderTakenSignal.OrderTaken += OnOrderTaken;
			
			NavigationSignals.SignalsProvider.DestinationDestroyedSignal.DestinationDestroyed
				+= OnDestinationDestroyed;
		}

		public void Detach() {
			DbSignals.SignalsProvider.DatabaseInitializedSignal.DatabaseInitialized 
				-= OnDbInitialized;
			
			ParkingSignals.SignalsProvider.RestAllowedSignal.RestAllowed -= OnRestAllowed;
			
			OrderSignals.SignalsProvider.OrderTakenSignal.OrderTaken -= OnOrderTaken;
			
			NavigationSignals.SignalsProvider.DestinationDestroyedSignal.DestinationDestroyed
				-= OnDestinationDestroyed;
		}

		private async void OnDbInitialized(EventSignalArgs args) =>
			_player = await DbService.Instance.DbProvider.PlayerRepository.GetFirstAsync();

		private void OnRestAllowed(ParkingSignals.RestAllowedArgs args) {
			if (! args.Allowed) {
				return;
			}
			Rest();
			_restPoint = args.ParkingPosition;
		}

		private void OnOrderTaken(OrderSignals.OrderArgs args) {
			if (_orderWorkflow.OrderState != OrderWorkflowState.Free) {
				return;
			}
			_orderWorkflow.TakeOrder(args.OrderId);
		}

		private async void OnDestinationDestroyed(EventSignalArgs args) {
			switch (_orderWorkflow.OrderState) {
				case OrderWorkflowState.Departure:
					_orderWorkflow.OrderState = OrderWorkflowState.Destination;
					break;

				case OrderWorkflowState.Destination:
					AddBalance();
					AddExperience();
					await DbService.Instance.DbProvider.PlayerRepository.UpdateByModelAsync(
						_player ?? throw new NullReferenceException("no connected player")
					);
					// _orderWorkflow.Complete();
					break;

				default: 
					break;
			}
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

		private void AddBalance() {
			if (_player?.Balance == null) {
				return;
			}
			_player.Balance += _orderWorkflow.Price;
		}

		private void AddExperience() {
			if (_player?.Experience == null) {
				return;
			}
			_player.Experience += _orderWorkflow.PathLength * 100f;
		}
	}
}
