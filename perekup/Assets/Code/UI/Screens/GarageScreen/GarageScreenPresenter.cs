using Assets.Code.Player;
using Assets.Code.StaticData;
using Assets.Code.UI.Infrastructure;
using System;


namespace Assets.Code.UI.Screens
{
    public sealed class GarageScreenPresenter
    {
        private readonly PlayerCarsStorage _playerCarsStorage;
        private readonly StaticDataService _staticData;
        private readonly UIManager _uiManager;

        private GarageScreenView _view;

        public GarageScreenPresenter(PlayerCarsStorage playerCarsStorage,
            StaticDataService staticData, UIManager uiManager)
        {
            _playerCarsStorage = playerCarsStorage;
            _staticData = staticData;
            _uiManager = uiManager;
        }

        public void Show(GarageScreenView view)
        {
            var playerCars = _playerCarsStorage.GetAllPlayerCars();

            _view = view;
            _view.FillCars(playerCars);
        }

        public void Hide()
        {

        }
    }
}
