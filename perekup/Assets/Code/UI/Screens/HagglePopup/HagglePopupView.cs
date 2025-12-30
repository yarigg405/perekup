using Assets.Code.Characters;
using Assets.Code.UI.Elements;
using Assets.Code.UI.Infrastructure;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yrr.Utils;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopupView : UIScreenView
    {
        [SerializeField] private Image _carIcon;
        [SerializeField] private TextMeshProUGUI _carVisualNameTmp;
        [SerializeField] private TextMeshProUGUI _carEstimatedCostTmp;

        [Space]
        [SerializeField] private CharacterPanelView _sellerCharacterView;
        [SerializeField] private CharacterPanelView _buyerCharacterView;

        [Space]
        [SerializeField] private TextMeshProUGUI _currentTradePriceTmp;
        [SerializeField] private TextMeshProUGUI _currentPercentOfAcceptingTmp;

        [field: SerializeField] public Slider PriceChangingSlider { get; private set; }
        [field: SerializeField] public Button BuyButton { get; private set; }

        [field: SerializeField] public Button TryConvinceBtn { get; private set; }
        [field: SerializeField] public Button TryLieBtn { get; private set; }
        [field: SerializeField] public Button TryCharmBtn { get; private set; }


        internal void SetCar(Sprite icon, string description, ulong estimatedCost)
        {
            _carIcon.sprite = icon;
            _carVisualNameTmp.text = description;
            _carEstimatedCostTmp.text = estimatedCost.ToShortMoneyString();
        }

        internal void SetSeller(Character seller, Sprite icon)
        {
            _sellerCharacterView.SetCharacter(seller, icon);
        }

        internal void SetBuyer(Character buyer, Sprite icon)
        {
            _buyerCharacterView.SetCharacter(buyer, icon);
        }

        internal void ChangeCurrentPrice(ulong currentPrice)
        {
            _currentTradePriceTmp.text = currentPrice.ToString("N0");
        }

        internal void ChangeAcceptingPercent(int acceptingPercent)
        {
            _currentPercentOfAcceptingTmp.text = $"{acceptingPercent}%";
        }



        public override void Show()
        {
            PriceChangingSlider.value = PriceChangingSlider.maxValue;
            base.Show();
        }
    }
}