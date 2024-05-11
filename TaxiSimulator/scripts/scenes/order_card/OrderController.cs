using System;
using Godot;
using TaxiSimulator.Common.Helpers.Dictionary;
using TaxiSimulator.Scenes.OrderCard.View;
using TaxiSimulator.Services.Db;
using ModelOrder = DbPackage.Models.Order;
using GameSceneSignals = TaxiSimulator.Scenes.GameScene.Signals;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Services.Order;
using OrdersServiceSignals = TaxiSimulator.Services.Order.Signals;
using System.Collections.Generic;

namespace TaxiSimulator.Scenes.OrderCard {
	public partial class OrderController : Control {
		private OrderContainer _ordersContainer;

		private PaginationContainer _paginationContainer;

		private TextureButton _leftArrowButton;

		private TextureButton _rightArrowButton;

		private int _currentOffset = 0;

		private int _pages;

		public override void _Ready() {
			base._Ready();
			Init();
			Attach();
			CallDeferred(nameof(ShowPages));	
		}

		public override void _Process(double delta) {
			base._Process(delta);

			_leftArrowButton.Disabled = _currentOffset == 0;
			_rightArrowButton.Disabled = _currentOffset == _pages - 1;
			CheckPagesDisableStatus();
		}

		private void Init() {
			_ordersContainer = GetNode<OrderContainer>(OrderContainer.NodePath);
			_paginationContainer = GetNode<PaginationContainer>(PaginationContainer.NodePath);
			_leftArrowButton = GetNode<TextureButton>("base_panel/TextureRect/LeftButtonBase/LeftButtonArrow");
			_rightArrowButton = GetNode<TextureButton>("base_panel/TextureRect/RightButtonBase/RightButtonArrow");
		}

		private void Attach() {
			_leftArrowButton.ButtonDown += () => {
				_currentOffset--;
				CallDeferred(nameof(LoadOrders));
			};

			_rightArrowButton.ButtonDown += () => {
				_currentOffset++;
				CallDeferred(nameof(LoadOrders));
			};

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					if (args.To != GameScene.GameMode.OrderGrid) {
						return;
					}
					CallDeferred(nameof(LoadOrders));
				})
			);

			OrdersServiceSignals.SignalsProvider.OrdersLoadedSignal.Attach(
				Callable.From((OrdersServiceSignals.OrdersArgs args) => {
					CallDeferred(nameof(ShowOrders), args);
				})
			);
		}

		private async void ShowPages() {
			var orderCount = await DbService.Instance.DbProvider
				.OrderRespository
				.CountByCompletedStatusAsync(false);
			
			_pages = orderCount / 3;
			_pages = orderCount % 3 != 0
				? _pages + 1
				: _pages;

			for (var i = 0; i < _pages; i++) {
				AddPagItem(i);
			}
		}

		private void CheckPagesDisableStatus() {
			for (var i = 0; i < _paginationContainer.GetChildCount(); i++) {
				if (_paginationContainer.GetChild(i) is PaginationItem paginationItem) {
					paginationItem.TextureButton.ButtonPressed = i != _currentOffset;
				}
			}
		}

		private void LoadOrders() => OrderService.Instance.LoadOrders(_currentOffset);

		private void ShowOrders(OrdersServiceSignals.OrdersArgs args) {
			ClearOrders();
			foreach (var order in args.Orders) {
				AddOrder(order);
			}
		}

		private void ClearOrders() {
			foreach (var order in _ordersContainer.GetChildren()) {
				order.QueueFree();
			}
		}

		private void AddOrder(ModelOrder modelOrder) {
			var orderCardScene = GD.Load<PackedScene>(ScenePathDictionary.OrderCardScenePath);
			var orderCard = orderCardScene.Instantiate<Order>();
			orderCard.Init();
			orderCard.SetOrder(modelOrder);
			_ordersContainer.AddChild(orderCard);
		}

		private void AddPagItem(int index) {
			var pagItemScene = GD.Load<PackedScene>(ScenePathDictionary.PaginationItemScenePath);
			var pagItem = pagItemScene.Instantiate<PaginationItem>();
			pagItem.TextureButton.ButtonPressed = index != 0;
			pagItem.Offset = index;
			pagItem.TextureButton.ButtonDown += () => {
				_currentOffset = pagItem.Offset;
				CallDeferred(nameof(LoadOrders));
			};
			_paginationContainer.AddChild(pagItem);
		}
	}
}
