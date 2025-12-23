using Assets.Code.UI.Infrastructure;
using System;
using System.Collections.Generic;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketScreenView : UIScreenView
    {
        [SerializeField] private Transform _cardsRoot;
        [SerializeField] private CarOrderCardView _cardPrefab;

        public event Action<string> OnOrderClicked;


        public void FillOrders(IEnumerable<CarOrderCardDTO> orders)
        {
            _cardsRoot.ClearChildren();

            foreach (var model in orders)
            {
                var card = GameObject.Instantiate(_cardPrefab, _cardsRoot);
                card.Setup(model, () => OnOrderClicked?.Invoke(model.OrderGuid));
            }
        }
    }
}