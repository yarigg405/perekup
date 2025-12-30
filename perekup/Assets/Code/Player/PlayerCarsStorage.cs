using Assets.Code.Cars;
using Assets.Code.Market;
using System;
using System.Collections.Generic;


namespace Assets.Code.Player
{
    public sealed class PlayerCarsStorage
    {
        private List<PlayerStoredCar> _playerCars = new();

        public IEnumerable<PlayerStoredCar> GetAllPlayerCars() => _playerCars;

        public void AddCarToStorage(CarOrder carOrder, ulong buyPrice)
        {
            _playerCars.Add(new()
            {
                OrderGuid = carOrder.OrderGuid,
                CarStats = carOrder.Stats,
                BuyPrice = buyPrice
            });
        }

        public void RemoveCarFromStorage(PlayerStoredCar car)
        {
            _playerCars.Remove(car);
        }
    }

    [Serializable]
    public sealed class PlayerStoredCar
    {
        public string OrderGuid { get; set; }
        public CarStats CarStats { get; set; }
        public ulong BuyPrice { get; set; }
    }
}
