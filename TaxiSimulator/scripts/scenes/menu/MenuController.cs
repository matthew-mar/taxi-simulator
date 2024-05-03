using TaxiSimulator.Common;
using TaxiSimulator.Scenes.Menu.Signals;

using TabSignals = TaxiSimulator.Scenes.Tab.Signals;
using LobbySignals = TaxiSimulator.Scenes.Lobby.Signals;

using Godot;

namespace TaxiSimulator.Scenes.Menu {
	public enum MenuState {
		Lobby,
		Map,
		OrdersGrid,
		Companies,
		RealEstate,
		Cars,
		Mail,
		Settings,
	}

	public partial class MenuController : Control {
		private MenuState? _previousState = null;

		private MenuState _currentState;

		public override void _Ready() {
			base._Ready();

			LobbySignals.SignalsProvider.MapButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Map);
				})
			);

			LobbySignals.SignalsProvider.OrdersButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.OrdersGrid);
				})
			);

			LobbySignals.SignalsProvider.CompanyButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Companies);
				})
			);

			LobbySignals.SignalsProvider.RealEstateButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.RealEstate);  
				})
			);

			LobbySignals.SignalsProvider.CarsButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Cars);                   
				})
			);

			LobbySignals.SignalsProvider.MailButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Settings);
				})
			);

			LobbySignals.SignalsProvider.SettingsButtonPressedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Settings);  
				})
			);

			TabSignals.SignalsProvider.TabClosedSignal.Attach(
				Callable.From((EventSignalArgs args) => {
					ChangeState(_currentState, MenuState.Lobby);
				})
			);

			ChangeState(null, MenuState.Lobby);
		}

		private void ChangeState(MenuState? from, MenuState to) {
			_previousState = from;
			_currentState = to;
			SignalsProvider.MenuStateChangedSignal.Emit(new StateChangedArgs() {
				FromState = _previousState,
				ToState = _currentState,
			});
		}
	}
}
