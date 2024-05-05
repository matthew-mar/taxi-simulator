using System;
using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Scenes.OrderCard.View;
using TaxiSimulator.Services.Db;
using ModelOrder = DbPackage.Models.Order;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;

namespace TaxiSimulator.Scenes.OrderCard {
	public partial class OrderController : Control {
		private OrderContainer _ordersContainer;

		public override void _Ready() {
			base._Ready();

			Init();

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					if (args.To != GameScene.GameMode.OrderGrid) {
						return;
					}

					ShowOrders();
				})
			);
		}

		private void Init() {
			_ordersContainer = GetNode<OrderContainer>(OrderContainer.NodePath);
		}

		private async void ShowOrders() {
			var orders = await DbService.Instance
				.DbProvider
				.OrderRespository
				.PaginateOrdersAsync(0);

			foreach (var order in orders) {
				AddOrder(order);
			}
		}

		private void AddOrder(ModelOrder modelOrder) {
			var orderCardScene = GD.Load<PackedScene>(ScenePathDictionary.OrderCardScenePath);
			var orderCard = orderCardScene.Instantiate<Order>();
			orderCard.Init();
			orderCard.SetOrder(modelOrder);
			_ordersContainer.AddChild(orderCard);
		}
	}
}
