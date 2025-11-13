using Assets.Code.Cars;
using System.Collections.Generic;


namespace Assets.Code.StaticData
{
    public sealed class StaticDataService
    {
        private Dictionary<string, CarConfigSO> _carConfigs = new();

        public StaticDataService(CarConfigSO[] cars)
        {
            foreach (var car in cars)
            {
                _carConfigs.Add(car.CarId, car);
            }
        }

        public IEnumerable<string> GetAllCarIds()
        {
            return _carConfigs.Keys;
        }

        public CarConfigSO GetCar(string carId)
        {
            return _carConfigs[carId];
        }
    }
}