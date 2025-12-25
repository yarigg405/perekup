using UnityEngine;
using Yrr.UI.Elements;

namespace Assets.Code.UI.Elements.PlayerMoneyPlank
{
    public sealed class PlayerMoneyPlankView : MonoBehaviour
    {
        [SerializeField] private TickableText _moneyValueTmp;

        public void SetupMoney(ulong money)
        {
            _moneyValueTmp.InitValue(money);
        }

        public void ChangeMoney(ulong money)
        {
            _moneyValueTmp.SmoothChangeValue(money);
        }
    }
}