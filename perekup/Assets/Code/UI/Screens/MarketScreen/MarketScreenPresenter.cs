using Assets.Code.Market;
using Assets.Code.StaticData;
using Assets.Code.UI.Infrastructure;
using System.Linq;
using VContainer;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketScreenPresenter
    {
        private readonly CarMarketService _service;
        private readonly StaticDataService _staticData;
        private readonly UIManager _uiManager;

        private MarketScreenView _view;

        public MarketScreenPresenter(IObjectResolver resolver)
        {
            _service = resolver.Resolve<CarMarketService>();
            _staticData = resolver.Resolve<StaticDataService>();
            _uiManager = resolver.Resolve<UIManager>();
        }

        public void Show(MarketScreenView view)
        {
            var orders = _service.GetCurrentOrders();
            var models = orders.Select(x => new CarOrderCardDTO(x, _staticData));

            _view = view;
            _view.FillOrders(models);
            _view.OnOrderClicked += HandleOrderClicked;
        }

        public void Hide()
        {
            _view.OnOrderClicked -= HandleOrderClicked;
        }

        private void HandleOrderClicked(string guid)
        {
            _uiManager.OpenScreen<MarketOrderDetailPopup>(_service.GetOrder(guid));
        }
    }
}
