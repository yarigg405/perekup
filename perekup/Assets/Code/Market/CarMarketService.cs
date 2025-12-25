using Assets.Code.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.Market
{
    public sealed class CarMarketService
    {
        private readonly StaticDataService _staticData;
        private readonly List<CarOrder> _tempOrders = new();

        public CarMarketService(StaticDataService staticData)
        {
            _staticData = staticData;

            for (int i = 0; i < 10; i++)
            {
                _tempOrders.Add(GenerateRandom());
            }
        }

        private CarOrder GenerateRandom()
        {
            return new CarOrder
            {
                OrderGuid = System.Guid.NewGuid().ToString(),
                Price = (ulong)Random.Range(100, 1300),
                Stats = new()
                {
                    CarId = _staticData.GetAllCarIds().GetRandomItem(),

                    BodyConditionReal = Random.Range(0f, 1f),
                    EngineCondidionReal = Random.Range(0f, 1f),
                    ChassisConditionReal = Random.Range(0f, 1f),
                    ElectricConditionReal = Random.Range(0f, 1f),
                    DocumentsConditionReal = Random.Range(0f, 1f),

                    BodyConditionKnown = Random.Range(0f, 1f),
                    EngineCondidionKnown = Random.Range(0f, 1f),
                    ChassisConditionKnown = Random.Range(0f, 1f),
                    ElectricConditionKnown = Random.Range(0f, 1f),
                    DocumentsConditionKnown = Random.Range(0f, 1f),
                },
            };
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
