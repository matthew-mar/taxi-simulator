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

		private PaginationContainer _paginationContainer;

		private TextureButton _leftArrowButton;

		private TextureButton _rightArrowButton;

		private int _currentOffset = 0;

		private int _pages;

		public override void _Ready() {
			base._Ready();

			Init();
			CallDeferred(nameof(ShowPages));

			GameSceneSignals.SignalsProvider.GameModeChangedSignal.Attach(
				Callable.From((GameSceneSignals.GameModeChangedArgs args) => {
					if (args.To != GameScene.GameMode.OrderGrid) {
						return;
					}

					CallDeferred(nameof(ShowOrders));
				})
			);
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
			_leftArrowButton.ButtonDown += () => {
				_currentOffset--;
				ShowOrders();
			};
			
			_rightArrowButton = GetNode<TextureButton>("base_panel/TextureRect/RightButtonBase/RightButtonArrow");
			_rightArrowButton.ButtonDown += () => {
				_currentOffset++;
				ShowOrders();
			};
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

		private async void ShowOrders() {
			ClearOrders();

			var orders = await DbService.Instance
				.DbProvider
				.OrderRespository
				.PaginateOrdersAsync(_currentOffset);

			foreach (var order in orders) {
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
				ShowOrders();
			};
			_paginationContainer.AddChild(pagItem);
		}
	}
}
