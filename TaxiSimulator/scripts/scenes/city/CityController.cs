using Godot;
using TaxiSimulator.Common.Helpers;
using TaxiSimulator.Scenes.City.View;
using TaxiSimulator.Services.Db;
using OrderSignals = TaxiSimulator.Scenes.OrderCard.Signals;

namespace TaxiSimulator.Scenes.City {
    public partial class CityController : Node3D {
        private NavRegion _navRegion;

        public override void _Ready() {
            base._Ready();

            Init();
            Connect();
        }

        private void Init() {
            _navRegion = GetNode<NavRegion>(NavRegion.NodePath);
        }

        private void Connect() {
            OrderSignals.SignalsProvider.OrderSelectedSignal.OrderSelected +=
                async (OrderSignals.OrderSelectedArgs args) => {
                    var order = await DbService.Instance.DbProvider
                        .OrderRespository
                        .GetOrderByIdAsync(args.OrderId);
                    
                    _navRegion.FindPath(
                        VectorConverter.FromDb(order.DeparturePoint),
                        VectorConverter.FromDb(order.DestinationPoint)
                    );
                };         
        }
    }
}
