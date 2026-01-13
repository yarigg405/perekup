using Assets.Code.Player;
using Assets.Code.UI.Infrastructure;
using System.Collections.Generic;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.UI.Screens
{
    public sealed class GarageScreenView : UIScreenView
    {
        [SerializeField] private Transform _cardsRoot;
        [SerializeField] private CarInGarageCardView _cardPrefab;


        public void FillCars(IEnumerable<PlayerStoredCar> playerCars)
        {
            _cardsRoot.ClearChildren();

            foreach (var car in playerCars)
            {
                var card = GameObject.Instantiate(_cardPrefab, _cardsRoot);
            }
        }
    }
}
