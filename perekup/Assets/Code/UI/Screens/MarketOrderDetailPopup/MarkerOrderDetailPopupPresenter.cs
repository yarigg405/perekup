using Assets.Code.Gameplay;
using Assets.Code.Market;
using Assets.Code.Player;
using Assets.Code.StaticData;
using Assets.Code.UI.Infrastructure;


namespace Assets.Code.UI.Screens
{
    public sealed class MarkerOrderDetailPopupPresenter
    {
        private readonly StaticDataService _staticData;
        private readonly UIManager _uIManager;
        private readonly CarInspectionService _inspectionService;
        private readonly CarPriceEstimateService _appraiseService;
        private readonly PlayerCharacterProvider _playerCharacterProvider;

        private MarketOrderDetailPopupView _view;
        private CarOrder _currentOrder;

        public MarkerOrderDetailPopupPresenter(CarInspectionService inspectionService,
            UIManager uIManager, StaticDataService staticData, CarPriceEstimateService appraiseService, PlayerCharacterProvider playerCharacterProvider)
        {
            _inspectionService = inspectionService;
            _uIManager = uIManager;
            _staticData = staticData;
            _appraiseService = appraiseService;
            _playerCharacterProvider = playerCharacterProvider;
        }

        internal void Show(MarketOrderDetailPopupView view, CarOrder order)
        {
            _currentOrder = order;
            _view = view;

            var car = _staticData.GetCar(order.Stats.CarId);
            _view.CarStatsPanelView.SetIcon(car.CarIcon);
            _view.CarStatsPanelView.SetDescription(car.VisualName);
            _view.CarStatsPanelView.InitStats(order.Stats);

            _view.SetPrice(order.Price);
            _view.SetRealPrice(_appraiseService.CalculateKnownPrice(order.Stats));

            _view.CloseButton.onClick.AddListener(ClickOnClose);
            _view.InspectConditionBtn.onClick.AddListener(ClickOnInspect);
            _view.InspectConditionBtn.interactable = true;
            _view.TradeBtn.onClick.AddListener(ClickOnTrade);
            _view.Show();
        }

        internal void Close()
        {
            _view.CloseButton.onClick.RemoveListener(ClickOnClose);
            _view.InspectConditionBtn.onClick.RemoveListener(ClickOnInspect);
            _view.TradeBtn.onClick.RemoveListener(ClickOnTrade);
            _view.Hide();
        }



        private void ClickOnClose()
        {
            _uIManager.CloseScreen<MarketOrderDetailPopup>();
        }

        private void ClickOnInspect()
        {
            _view.InspectConditionBtn.interactable = false;
            _inspectionService.Inspect(_currentOrder.Stats, _playerCharacterProvider.PlayerCharacter);
            _view.CarStatsPanelView.RefreshStats(_currentOrder.Stats);
            _view.SetRealPrice(_appraiseService.CalculateKnownPrice(_currentOrder.Stats));
        }

        private void ClickOnTrade()
        {
            _uIManager.CloseScreen<MarketOrderDetailPopup>();
            _uIManager.OpenScreen<HagglePopup>(_currentOrder);
        }
    }
}
