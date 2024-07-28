using TaxiSimulator.Scenes.Lobby.Signals;
using TaxiSimulator.Scenes.Lobby.View.Buttons;
using MenuSignals = TaxiSimulator.Scenes.Menu.Signals;
using PlayerSignals = TaxiSimulator.Services.Player.Signals;

using Godot;
using TaxiSimulator.Scenes.Lobby.View.PlayerCard;

namespace TaxiSimulator.Scenes.Lobby {
	public partial class LobbyController : Control {
		private DriveButton _driveButton;

		private QuitButton _quitButton;

		private MapButton _mapButton;

		private OrdersButton _ordersButton;

		private CompanyButton _companyButton;

		private RealEstateButton _realEstateButton;

		private CarsButton _carsButton;

		private MailButton _mailButton;

		private SettingsButton _settingsButton;

		private Level _level;

		private ExperienceBar _experienceBar;

		private Balance _balance;

		private OrdersComplete _ordersComplete;

		private Raiting _raiting;

		public override void _Ready() {
			base._Ready();
			Init();
			Connect();
		}

		private void Connect() {
			ConnectButtons();
			ConnectMenu();
			ConnectPlayer();
		}

		private void ConnectPlayer() {
			PlayerSignals.SignalsProvider.ExperienceSignal.Attach(
				Callable.From((PlayerSignals.ExperienceArgs args) => {
					_level.SetLevel(args.Experience);
					_experienceBar.SetValue(args.Experience);
				})
			);

			PlayerSignals.SignalsProvider.BalanceSignal.Attach(
				Callable.From((PlayerSignals.BalanceArgs args) => {
					_balance.SetBalance(args.Balance);
				})
			);
		}

		private void ConnectMenu() {
			MenuSignals.SignalsProvider.MenuStateChangedSignal.Attach(
				Callable.From((MenuSignals.StateChangedArgs args) => {
					Visible = args.ToState == Menu.MenuState.Lobby;
					if (Visible) {
						_ordersComplete.SetOrders();
						_raiting.SetRaiting();
					}
				})
			);
		}

		private void Init() {
			InitButtons();
			InitPlayerCard();
		}

		private void InitButtons() {
			_driveButton = GetNode<DriveButton>(DriveButton.NodePath);
			_quitButton = GetNode<QuitButton>(QuitButton.NodePath);
			_mapButton = GetNode<MapButton>(MapButton.NodePath);
			_ordersButton = GetNode<OrdersButton>(OrdersButton.NodePath);
			_companyButton = GetNode<CompanyButton>(CompanyButton.NodePath);
			_realEstateButton = GetNode<RealEstateButton>(RealEstateButton.NodePath);
			_carsButton = GetNode<CarsButton>(CarsButton.NodePath);
			_mailButton = GetNode<MailButton>(MailButton.NodePath);
			_settingsButton = GetNode<SettingsButton>(SettingsButton.NodePath);	
		}

		private void InitPlayerCard() {
			_level = GetNode<Level>(Level.NodePath);
			_experienceBar = GetNode<ExperienceBar>(ExperienceBar.NodePath);
			_balance = GetNode<Balance>(Balance.NodePath);
			_ordersComplete = GetNode<OrdersComplete>(OrdersComplete.NodePath);
			_raiting = GetNode<Raiting>(Raiting.NodePath);
		}

		private void ConnectButtons() {
			_driveButton.ButtonDown += () => {
				SignalsProvider.DriveButtonPressedSignal.Emit();
			};

			_quitButton.ButtonDown += () => {
				SignalsProvider.QuitButtonPressedSignal.Emit();
			};

			_mapButton.ButtonDown += () => {
				SignalsProvider.MapButtonPressedSignal.Emit();
			};

			_ordersButton.ButtonDown += () => {
				SignalsProvider.OrdersButtonPressedSignal.Emit();
			};

			_companyButton.ButtonDown += () => {
				SignalsProvider.CompanyButtonPressedSignal.Emit();
			};

			_realEstateButton.ButtonDown += () => {
				SignalsProvider.RealEstateButtonPressedSignal.Emit();
			};

			_carsButton.ButtonDown += () => {
				SignalsProvider.CarsButtonPressedSignal.Emit();
			};

			_mailButton.ButtonDown += () => {
				SignalsProvider.MailButtonPressedSignal.Emit();
			};

			_settingsButton.ButtonDown += () => {
				SignalsProvider.SettingsButtonPressedSignal.Emit();
			};
		}
	}
}
