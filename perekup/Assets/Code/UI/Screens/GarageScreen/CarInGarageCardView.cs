using TMPro;
using UnityEngine;
using Yrr.UI.Elements;
using UnityEngine.UI;


namespace Assets.Code.UI.Screens
{
    public sealed class CarInGarageCardView : MonoBehaviour
    {
        [SerializeField] private Image _carIcon;
        [SerializeField] private TextMeshProUGUI _carDescriptionTmp;
        [SerializeField] private SmoothSlider _conditionSlider;

        [field: SerializeField] public Button CardClickButton { get; private set; }
    }
}
