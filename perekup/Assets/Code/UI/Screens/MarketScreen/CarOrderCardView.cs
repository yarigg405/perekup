using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yrr.UI.Elements;


namespace Assets.Code.UI.Screens.MarketScreen
{
    public sealed class CarOrderCardView : MonoBehaviour
    {
        [SerializeField] private Image _carIcon;
        [SerializeField] private TextMeshProUGUI _carDescriptionTmp;
        [SerializeField] private SmoothSlider _conditionSlider;
        [SerializeField] private TextMeshProUGUI _carPrice;
        [SerializeField] private Button _openOrderButton;

        private Action _onButtonClicked;

        private void OnEnable()
        {
            _openOrderButton.onClick.AddListener(HandleButtonClicked);
        }

        private void OnDisable()
        {
            _openOrderButton.onClick.RemoveListener(HandleButtonClicked);
        }

        public void Setup(CarOrderCardDTO model, Action onButtonClicked)
        {
            _carIcon.sprite = model.CarIcon;
            _carDescriptionTmp.text = model.CarDescription;
            _conditionSlider.InitValue(0);
            _conditionSlider.ChangeValue(model.CarCondition);
            _carPrice.text = model.OrderPrice;

            _onButtonClicked = onButtonClicked;
        }

        private void HandleButtonClicked()
        {
            _onButtonClicked?.Invoke();
        }
    }
}
