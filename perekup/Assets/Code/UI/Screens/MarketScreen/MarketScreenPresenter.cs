using Assets.Code.Market;
using Assets.Code.StaticData;
using System.Linq;


namespace Assets.Code.UI.Screens.MarketScreen
{
    public sealed class MarketScreenPresenter
    {
        private readonly CarMarketService _service;
        private readonly StaticDataService _staticData;

        public MarketScreenPresenter(CarMarketService service, StaticDataService staticData)
        {
            _service = service;
            _staticData = staticData;
        }

        public void Show(MarketScreenView view)
        {
            var orders = _service.GetCurrentOrders();
            var models = orders.Select(x => new CarOrderCardDTO(x, _staticData));

            view.FillOrders(models);
        }
    }
}
