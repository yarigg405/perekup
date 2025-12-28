using Assets.Code.UI.Elements.CarStatsPanel;
using Assets.Code.UI.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yrr.UI.Elements;
using Yrr.Utils;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketOrderDetailPopupView : UIScreenView
    {
        [SerializeField] private CarStatsPanelView _carStatsPanel;
        [SerializeField] private TickableText _orderPriceTmp;
        [SerializeField] private TextMeshProUGUI _realPriceTmp;

        [field: SerializeField] public Button InspectConditionBtn { get; private set; }
        [field: SerializeField] public Button TryFraudBtn { get; private set; }
        [field: SerializeField] public Button TradeBtn { get; private set; }

        public CarStatsPanelView CarStatsPanelView => _carStatsPanel;

        public void SetPrice(ulong price)
        {
            _orderPriceTmp.InitValue(0);
            _orderPriceTmp.SmoothChangeValue(price);
        }

        public void SetRealPrice(ulong realPrice)
        {
            _realPriceTmp.text = realPrice.ToShortMoneyString();
        }
    }
}