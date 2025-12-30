using Assets.Code.Characters;
using Assets.Code.Gameplay;
using Assets.Code.Market;
using Assets.Code.Player;
using Assets.Code.StaticData;
using Assets.Code.UI.Infrastructure;
using UnityEngine;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopupPresenter
    {
        private readonly UIManager _uIManager;
        private readonly CharactersGenerationStorage _charactersConfig;
        private readonly StaticDataService _staticDataService;
        private readonly PlayerCharacterProvider _playerCharacterProvider;
        private readonly CharactersStorageService _charactersStorageService;
        private readonly CarPriceEstimateService _carEstimateService;
        private readonly HagglingService _hagglingService;

        private HagglePopupView _view;
        private CarOrder _currentOrder;
        private Character _seller;
        private Character _buyer;

        private ulong _currentPrice;
        private int _percentModificator;
        private int _currentPercent;

        public HagglePopupPresenter(UIManager uIManager, CharactersGenerationStorage charactersConfig,
            StaticDataService staticDataService, PlayerCharacterProvider playerCharacterProvider,
            CharactersStorageService charactersStorageService, CarPriceEstimateService carEstimateService,
            HagglingService hagglingService)
        {
            _uIManager = uIManager;
            _charactersConfig = charactersConfig;
            _staticDataService = staticDataService;
            _playerCharacterProvider = playerCharacterProvider;
            _charactersStorageService = charactersStorageService;
            _carEstimateService = carEstimateService;
            _hagglingService = hagglingService;
        }

        internal void Show(HagglePopupView view, CarOrder order)
        {
            _currentOrder = order;

            _view = view;
            _view.CloseButton.onClick.AddListener(ClickOnClose);
            _view.TryConvinceBtn.onClick.AddListener(ClickOnTryConvince);
            _view.TryLieBtn.onClick.AddListener(ClickOnTryLie);
            _view.TryCharmBtn.onClick.AddListener(ClickOnTryCharm);

            _view.TryConvinceBtn.interactable = true;
            _view.TryLieBtn.interactable = true;
            _view.TryCharmBtn.interactable = true;

            var carConfig = _staticDataService.GetCar(_currentOrder.Stats.CarId);
            var estimatedPrice = _carEstimateService.CalculateKnownPrice(_currentOrder.Stats);
            _view.SetCar(carConfig.CarIcon, carConfig.VisualName, estimatedPrice);

            _seller = _charactersStorageService.GetCharacter(_currentOrder.SellerId);
            var sellerIcon = _seller.Gender == CharacterGender.Male ?
                _charactersConfig.MaleFaces[_seller.IconIndex] :
                _charactersConfig.FemaleFaces[_seller.IconIndex];
            _view.SetSeller(_seller, sellerIcon);

            _buyer = _playerCharacterProvider.PlayerCharacter;
            var playerIcon = _buyer.Gender == CharacterGender.Male ?
                _charactersConfig.MaleFaces[_buyer.IconIndex] :
                _charactersConfig.FemaleFaces[_buyer.IconIndex];
            _view.SetBuyer(_buyer, playerIcon);

            _currentPrice = _currentOrder.Price;
            _currentPercent = 100;
            _percentModificator = _hagglingService.GetStartAcceptingSellingModificator(_seller);

            _view.ChangeCurrentPrice(_currentPrice);
            _view.ChangeAcceptingPercent(_currentPercent);

            _view.PriceChangingSlider.onValueChanged.AddListener(HandleSliderChanged);

            _view.Show();
        }

        internal void Close()
        {
            _view.PriceChangingSlider.onValueChanged.RemoveListener(HandleSliderChanged);
            _view.CloseButton.onClick.RemoveListener(ClickOnClose);

            _view.TryConvinceBtn.onClick.RemoveListener(ClickOnTryConvince);
            _view.TryLieBtn.onClick.RemoveListener(ClickOnTryLie);
            _view.TryCharmBtn.onClick.RemoveListener(ClickOnTryCharm);

            _view.Hide();
        }

        private void ClickOnClose()
        {
            _uIManager.CloseScreen<HagglePopup>();
        }

        private void ClickOnTryConvince()
        {
            _view.TryConvinceBtn.interactable = false;
            _percentModificator += _hagglingService.ResultOfConvincing(_buyer, _seller);
            RecalculateAcceptingPercent();
        }

        private void ClickOnTryLie()
        {
            _view.TryLieBtn.interactable = false;
            _percentModificator += _hagglingService.ResultOfLie(_buyer, _seller);
            RecalculateAcceptingPercent();
        }

        private void ClickOnTryCharm()
        {
            _view.TryCharmBtn.interactable = false;
            _percentModificator += _hagglingService.ResultOfCharming(_buyer, _seller);
            RecalculateAcceptingPercent();
        }


        private void HandleSliderChanged(float sliderValue)
        {
            RecalculatePrice();
            RecalculateAcceptingPercent();
        }

        private void RecalculatePrice()
        {
            _currentPrice = (ulong)(_currentOrder.Price * _view.PriceChangingSlider.value);
            _view.ChangeCurrentPrice(_currentPrice);
        }

        private void RecalculateAcceptingPercent()
        {
            _currentPercent = Mathf.RoundToInt(_view.PriceChangingSlider.value * 100f) + _percentModificator;
            _currentPercent = Mathf.Clamp(_currentPercent, 0, 100);
            _view.ChangeAcceptingPercent(_currentPercent);

            _view.BuyButton.interactable = _currentPercent >= 100;
        }
    }
}
