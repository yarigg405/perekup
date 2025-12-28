using TMPro;
using UnityEngine;


namespace Yrr.UI.Elements
{
    public sealed class CustomSliderPercentText : MonoBehaviour
    {
        [SerializeField] private SmoothSlider _slider;
        [SerializeField] private TextMeshProUGUI _percentText;

        private void OnEnable()
        {
            _slider.OnSliderValueUpdated += OnSliderChanged;
            OnSliderChanged(_slider.CurrentValue);
        }

        private void OnDisable()
        {
            _slider.OnSliderValueUpdated -= OnSliderChanged;
        }

        private void OnSliderChanged(float sliderValue)
        {
            var rounded = Mathf.Round(sliderValue * 100);
            _percentText.text = $"{rounded}%";
        }
    }
}