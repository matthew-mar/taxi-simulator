using Godot;
using System;
using TaxiSimulator.Services.Db;
using ModelOrder = DbPackage.Models.Order;

namespace TaxiSimulator.Scenes.OrderCard.View {
	public partial class Order : Control {
		private CompanyName _companyName;

		private Cost _cost;

		private Departure _departure;

		private Destination _destination;

		private Distance _distance;

		private CreatedAt _createdAt;

		private CompanyIcon _companyIcon;

		public void SetOrder(ModelOrder order) {
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
		}

		public void Init() {
			_companyName = GetNode<CompanyName>(CompanyName.NodePath);
			_cost = GetNode<Cost>(Cost.NodePath);
			_departure = GetNode<Departure>(Departure.NodePath);
			_destination = GetNode<Destination>(Destination.NodePath);
			_distance = GetNode<Distance>(Distance.NodePath);
			_createdAt = GetNode<CreatedAt>(CreatedAt.NodePath);
			_companyIcon = GetNode<CompanyIcon>(CompanyIcon.NodePath);
		}

		private async void SetCompany(int companyId) {
			var company = await DbService.Instance.DbProvider
				.CompanyRepository
				.GetByIdAsync(companyId);
			var companyName = company.Name ?? throw new NullReferenceException("company has no name");
			_companyName.SetText(companyName);
			_companyIcon.SetIcon(company.IconPath 
				?? throw new NullReferenceException("company has no icon path")
			);
		}

		private void SetCost(float cost) => _cost.SetText($"{cost}");

		private void SetDeparture(string departure) => _departure.SetText(departure);

		private void SetDestination(string destination) => _destination.SetText(destination);

		private void SetDistance(string distance) => _distance.SetText(distance);

		private void SetCreatedAt(long createdAt) {
			var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(createdAt);
			var hours = dateTimeOffset.DateTime.Hour;
			var minutes = dateTimeOffset.DateTime.Minute;
			_createdAt.SetText($"{hours:d2}:{minutes:d2}");
		}
	}
}
