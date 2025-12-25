using Assets.Code.Market;
using System.Collections.Generic;


namespace Assets.Code.Player
{
    public sealed class PlayerCarsStorage
    {
        private List<CarOrder> _playerOwnedCars = new();

        public IEnumerable<CarOrder> GetPlayerOwnedCars()
            => _playerOwnedCars;

        public void AddNewCar(CarOrder order)
        {
            _playerOwnedCars.Add(order);
        }

    }
}
