using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.Market
{
    public sealed class CarMarketService
    {
        private readonly CarOrderGenerator _carOrderGenerator;

        private readonly List<CarOrder> _tempOrders = new();
        private readonly Vector2Int _ordersCountMinMax = new(15, 25);

        public CarMarketService(CarOrderGenerator carOrderGenerator)
        {
            _carOrderGenerator = carOrderGenerator;


            for (int i = 0; i < _ordersCountMinMax.GetRandomValue(); i++)
            {
                _tempOrders.Add(_carOrderGenerator.GenerateRandomOrder());
            }
        }

        public IEnumerable<CarOrder> GetCurrentOrders()
        {
            return _tempOrders;
        }

        public CarOrder GetOrder(string orderGuid)
        {
            return _tempOrders.First(x => x.OrderGuid == orderGuid);
        }
    }
}
