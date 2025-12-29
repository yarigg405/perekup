using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.UI.Elements
{
    public sealed class CharacterPanelView : MonoBehaviour
    {
        [SerializeField] private Image _characterIcon;
        [SerializeField] private TextMeshProUGUI _characterName;

        [Space(10)]
        [SerializeField] private TextMeshProUGUI _strengthTmp;
        [SerializeField] private TextMeshProUGUI _agilityTmp;
        [SerializeField] private TextMeshProUGUI _constitutionTmp;

        [SerializeField] private TextMeshProUGUI _intelligenceTmp;
        [SerializeField] private TextMeshProUGUI _wisdomTmp;
        [SerializeField] private TextMeshProUGUI _charismaTmp;
    }
}