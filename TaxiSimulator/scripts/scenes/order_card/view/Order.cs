using Godot;
using System;
using DbPackage.Models;
using TaxiSimulator.Services.Db;
using ModelOrder = DbPackage.Models.Order;
using TaxiSimulator.Common.View;
using TaxiSimulator.Scenes.OrderCard.Signals;
using DbPackage.Structures;
using TaxiSimulator.Common.Helpers;

namespace TaxiSimulator.Scenes.OrderCard.View {
	public partial class Order : Control {
		private CompanyName _companyName;

		private Cost _cost;

		private Departure _departure;

		private Destination _destination;

		private Distance _distance;

		private CreatedAt _createdAt;

		private CompanyIcon _companyIcon;

		private TarifPlanLabel _tarifPlanLabel;

		private WaitTime _waitTime;

		private ExpectTime _expectTime;

		private ModelOrder _order;

		private OrderButton _orderButton;

		private TakeButton _takeButton;

		public void SetOrder(ModelOrder order) {
			_order = order;
			SetCompany(
				order.CompanyId ?? throw new NullReferenceException("order has no company id")
			);
			SetCost(order.Price ?? throw new NullReferenceException("order has no cost"));
			SetDeparture(
				order.DepartureName ?? throw new NullReferenceException("order has no departure")
			);
			SetDestination(
				order.DestinationName ?? throw new NullReferenceException("order has no destination")
			);
			SetCreatedAt(
				order.CreatedAt ?? throw new NullReferenceException("order has no created at")
			);
			SetTarifPlan(
				order.TarifPlanId ?? throw new NullReferenceException("order has no tarif plan")
			);
			SetWaitTime(
				order.StartTime ?? throw new NullReferenceException("order has no start time")
			);
			SetExpectTime(
				order.EndTime ?? throw new NullReferenceException("order has no end time")
			);
			SetDistance(order.DeparturePoint, order.DestinationPoint);
		}

		public void Init() {
			_companyName = GetNode<CompanyName>(CompanyName.NodePath);
			_cost = GetNode<Cost>(Cost.NodePath);
			_departure = GetNode<Departure>(Departure.NodePath);
			_destination = GetNode<Destination>(Destination.NodePath);
			_distance = GetNode<Distance>(Distance.NodePath);
			_createdAt = GetNode<CreatedAt>(CreatedAt.NodePath);
			_companyIcon = GetNode<CompanyIcon>(CompanyIcon.NodePath);
			_tarifPlanLabel = GetNode<TarifPlanLabel>(TarifPlanLabel.NodePath);
			_waitTime = GetNode<WaitTime>(WaitTime.NodePath);
			_expectTime = GetNode<ExpectTime>(ExpectTime.NodePath);
			
			_orderButton = GetNode<OrderButton>(OrderButton.NodePath);
			_orderButton.ButtonUp += () => {
				SignalsProvider.OrderSelectedSignal.Emit(new OrderArgs() {
					OrderId = _order.Id,
				});
			};

			_takeButton = GetNode<TakeButton>(TakeButton.NodePath);
			_takeButton.ButtonDown += async () => {
				_order.TakenAt = TimeTool.NowTimestamp;
				await DbService.Instance.DbProvider.OrderRespository.UpdateByModelAsync(_order);
				SignalsProvider.OrderTakenSignal.Emit(new OrderArgs() {
					OrderId = _order.Id,
				});
			};
		}

		private async void SetCompany(int companyId) {
			var company = await DbService.Instance.DbProvider
				.CompanyRepository
				.GetByIdAsync(companyId);
			var companyName = company.Name ?? throw new NullReferenceException("company has no name");
			_companyName.SetText(companyName);
			CallDeferred(
				nameof(SetIcon), 
				company.IconPath 
				?? throw new NullReferenceException("company has no icon")
			);
		}

		private void SetIcon(string iconPath) => _companyIcon.SetIcon(iconPath);

		private void SetCost(float cost) => _cost.SetText($"{cost}");

		private void SetDeparture(string departure) => _departure.SetText(departure);

		private void SetDestination(string destination) => _destination.SetText(destination);

		private void SetDistance(DbVector from, DbVector to) {
			float distance = Mathf.Sqrt(
				Mathf.Pow(from.X - to.X, 2) +
				Mathf.Pow(from.Y - to.Y, 2) +
				Mathf.Pow(from.Z - to.Z, 2)
			) / 1000;
			_distance.SetText($"{distance:F2}");
		}

		private void SetCreatedAt(long createdAt) => SetTime(createdAt, _createdAt);

		private void SetTarifPlan(int tarifPlanId) 
			=> _tarifPlanLabel.SetText(TarifPlanName.TarifPlan(tarifPlanId));

		private void SetWaitTime(long startTime) => SetTime(startTime, _waitTime);

		private void SetExpectTime(long endTime) => SetTime(endTime, _expectTime);

		private static void SetTime(long timestamp, CommonText timeNode) {
			var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
			var hours = dateTimeOffset.DateTime.Hour;
			var minutes = dateTimeOffset.DateTime.Minute;
			timeNode.SetText($"{hours:d2}:{minutes:d2}");
		}
	}
}
