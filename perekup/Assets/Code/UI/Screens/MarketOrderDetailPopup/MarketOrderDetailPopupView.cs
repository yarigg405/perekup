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

        [field: SerializeField] public Button InspectConditionBtn { get; private set; }
        [field: SerializeField] public Button TryFraudBtn { get; private set; }
        [field: SerializeField] public Button TradeBtn { get; private set; }

        public CarStatsPanelView CarStatsPanelView => _carStatsPanel;

        public void SetPrice(ulong price)
        {
            _orderPriceTmp.InitValue(0);
            _orderPriceTmp.SmoothChangeValue(price);
        }
    }
}