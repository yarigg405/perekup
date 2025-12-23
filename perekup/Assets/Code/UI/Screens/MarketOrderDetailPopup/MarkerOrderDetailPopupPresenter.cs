using Assets.Code.Market;
using Assets.Code.StaticData;
using Assets.Code.UI.Infrastructure;
using System;


namespace Assets.Code.UI.Screens
{
    public sealed class MarkerOrderDetailPopupPresenter
    {
        private readonly StaticDataService _staticData;
        private readonly UIManager _uIManager;

        public MarkerOrderDetailPopupPresenter(StaticDataService staticData, UIManager uIManager)
        {
            _staticData = staticData;
            _uIManager = uIManager;
        }

        private MarketOrderDetailPopupView _view;
        private CarOrder _currentOrder;

        internal void Show(MarketOrderDetailPopupView view, CarOrder order)
        {
            _currentOrder = order;
            _view = view;

            var car = _staticData.GetCar(order.Stats.CarId);
            _view.CarStatsPanelView.SetIcon(car.CarIcon);
            _view.CarStatsPanelView.SetDescription(car.GetDescription());
            _view.CarStatsPanelView.InitStats(order.Stats);

            _view.SetPrice(order.Price);

            _view.CloseButton.onClick.AddListener(ClickOnClose);
            _view.Show();
        }

        internal void Close()
        {
            _view.CloseButton.onClick.RemoveListener(ClickOnClose);
            _view.Hide();
        }

        private void ClickOnClose()
        {
            _uIManager.CloseScreen<MarketOrderDetailPopup>();
        }
    }
}
