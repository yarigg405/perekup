using Assets.Code.Market;
using Assets.Code.StaticData;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.UI.Screens.MarketScreen
{
    public readonly struct CarOrderCardDTO
    {
        public readonly Sprite CarIcon;
        public readonly string CarDescription;
        public readonly float CarCondition;
        public readonly string OrderPrice;
        public readonly string OrderGuid;

        public CarOrderCardDTO(CarOrder order, StaticDataService staticData)
        {
            var config = staticData.GetCar(order.Stats.CarId);

            CarIcon = config.CarIcon;
            CarDescription = $"{config.CarBrandName} {config.CarModelName} ({config.Year})";
            CarCondition = CalculateStatsValue(order);
            OrderPrice = order.Price.ToShortMoneyString();
            OrderGuid = order.OrderGuid;
        }

        private static float CalculateStatsValue(CarOrder carOrder)
        {
            var stats = carOrder.Stats;

            float total =
                stats.BodyConditionKnown +
                stats.ChassisConditionKnown +
                stats.ElectricConditionKnown +
                stats.EngineCondidionKnown;

            return total / 4f;
        }
    }
}
