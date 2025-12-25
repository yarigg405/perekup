using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopupPresenter
    {
        private readonly UIManager _uIManager;

        private HagglePopupView _view;
        private CarOrder _current

        public HagglePopupPresenter(UIManager uIManager)
        {
            _uIManager = uIManager;
        }

        internal void Show(HagglePopupView view, CarOrder order)
        {
            _view = view;
            _view.CloseButton.onClick.AddListener(ClickOnClose);
        }

        internal void Close()
        {
            _view.CloseButton.onClick.RemoveListener(ClickOnClose);
            _vi
        }

        private void ClickOnClose()
        {
            _uIManager.CloseScreen<MarketOrderDetailPopup>();
        }
    }
}
