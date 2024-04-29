using TaxiSimulator.Scenes.Lobby.View;
using TaxiSimulator.Scenes.Lobby.Signals;
using MenuSignals = TaxiSimulator.Scenes.Menu.Signals;

using Godot;

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

		public override void _Ready() {
			base._Ready();

			_driveButton = GetNode<DriveButton>(DriveButton.NodePath);
			_quitButton = GetNode<QuitButton>(QuitButton.NodePath);
			_mapButton = GetNode<MapButton>(MapButton.NodePath);
			_ordersButton = GetNode<OrdersButton>(OrdersButton.NodePath);
			_companyButton = GetNode<CompanyButton>(CompanyButton.NodePath);
			_realEstateButton = GetNode<RealEstateButton>(RealEstateButton.NodePath);
			_carsButton = GetNode<CarsButton>(CarsButton.NodePath);
			_mailButton = GetNode<MailButton>(MailButton.NodePath);
			_settingsButton = GetNode<SettingsButton>(SettingsButton.NodePath);	

			MenuSignals.SignalsProvider.MenuStateChangedSignal.Attach(
				Callable.From((MenuSignals.StateChangedArgs args) => {
					Visible = args.ToState == Menu.MenuState.Lobby;
				})
			);

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
