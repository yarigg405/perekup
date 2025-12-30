using Assets.Code.Characters;
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

        internal void SetCharacter(Character character, Sprite icon)
        {
            _characterIcon.sprite = icon;
            _characterName.text = character.VisualName;

            _strengthTmp.text = $"Убеждение {GetStatBonusText(character.GetStatBonus(CharacterStats.Strength))}";
            _agilityTmp.text = $"Хитрость {GetStatBonusText(character.GetStatBonus(CharacterStats.Agility))}";
            _constitutionTmp.text = $"Стойкость {GetStatBonusText(character.GetStatBonus(CharacterStats.Constitution))}";

            _intelligenceTmp.text = $"Интеллект {GetStatBonusText(character.GetStatBonus(CharacterStats.Intelligence))}";
            _wisdomTmp.text = $"Внимание {GetStatBonusText(character.GetStatBonus(CharacterStats.Wisdom))}";
            _charismaTmp.text = $"Харизма {GetStatBonusText(character.GetStatBonus(CharacterStats.Charisma))}";
        }

        private string GetStatBonusText(int modificator)
        {
            return " (" + (modificator < 0 ? modificator + ")" : ("+" + modificator) + ")");
        }
    }
}