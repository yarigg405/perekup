using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopupPresenter
    {
        private readonly UIManager _uIManager;

        private HagglePopupView _view;
        private CarOrder _currentOrder;

        public HagglePopupPresenter(UIManager uIManager)
        {
            _uIManager = uIManager;
        }

        internal void Show(HagglePopupView view, CarOrder order)
        {
            _view = view;
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
