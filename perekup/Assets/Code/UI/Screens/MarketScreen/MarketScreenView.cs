using Assets.Code.UI.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.UI.Screens.MarketScreen
{
    public sealed class MarketScreenView : UIScreenView
    {
        [SerializeField] private Transform _cardsRoot;
        [SerializeField] private CarOrderCardView _cardPrefab;


        public void FillOrders(IEnumerable<CarOrderCardDTO> orders)
        {
            _cardsRoot.ClearChildren();

            foreach (var model in orders)
            {
                var card = GameObject.Instantiate(_cardPrefab, _cardsRoot);
                card.Setup(model, () => HandleOrderClick(model.OrderGuid));
            }
        }

        private void HandleOrderClick(string orderGuid)
        {

        }
    }
}