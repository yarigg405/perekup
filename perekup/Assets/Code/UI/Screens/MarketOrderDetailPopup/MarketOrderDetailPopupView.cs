using Assets.Code.UI.Elements.CarStatsPanel;
using Assets.Code.UI.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Yrr.UI.Elements;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketOrderDetailPopupView : UIScreenView
    {
        [SerializeField] private CarStatsPanelView _carStatsPanel;
        [SerializeField] private TickableText _orderPriceTmp;

        [SerializeField] private Button _checkConditionBtn;
        [SerializeField] private Button _tryFraudBtn;
        [SerializeField] private Button _tradeBtn;

        public CarStatsPanelView CarStatsPanelView => _carStatsPanel;

        public void SetPrice(ulong price)
        {
            _orderPriceTmp.InitValue(0);
            _orderPriceTmp.SmoothChangeValue(price);
        }
    }
}