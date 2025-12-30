using Assets.Code.Cars;
using Assets.Code.StaticData;


namespace Assets.Code.Market
{
    public sealed class CarPriceEstimateService
    {
        private const float _bodyCostModifier = 0.3f;
        private const float _engineCostModifier = 0.25f;
        private const float _chassisCostModifier = 0.2f;
        private const float _electricCostModifier = 0.15f;
        private const float _documentsCostModifier = 0.1f;


        private readonly StaticDataService _staticData;

        public CarPriceEstimateService(StaticDataService staticData)
        {
            _staticData = staticData;
        }

        public ulong CalculateKnownPrice(CarStats stats)
        {
            var idealPrice = _staticData.GetCar(stats.CarId).PriceIdealCondition;

            var bodyPrice = idealPrice * _bodyCostModifier * CalculateConditionModifier(stats.BodyConditionKnown);
            var enginePrice = idealPrice * _engineCostModifier * CalculateConditionModifier(stats.EngineCondidionKnown);
            var chassisPrice = idealPrice * _chassisCostModifier * CalculateConditionModifier(stats.ChassisConditionKnown);
            var electricPrice = idealPrice * _electricCostModifier * CalculateConditionModifier(stats.ElectricConditionKnown);
            var documentsPrice = idealPrice * _documentsCostModifier * CalculateConditionModifier(stats.DocumentsConditionKnown);

            return (ulong)(bodyPrice + enginePrice + chassisPrice + electricPrice + documentsPrice);
        }

        public ulong CalculateRealPrice(CarStats stats)
        {
            var idealPrice = _staticData.GetCar(stats.CarId).PriceIdealCondition;

            var bodyPrice = idealPrice * _bodyCostModifier * CalculateConditionModifier(stats.BodyConditionReal);
            var enginePrice = idealPrice * _engineCostModifier * CalculateConditionModifier(stats.EngineCondidionReal);
            var chassisPrice = idealPrice * _chassisCostModifier * CalculateConditionModifier(stats.ChassisConditionReal);
            var electricPrice = idealPrice * _electricCostModifier * CalculateConditionModifier(stats.ElectricConditionReal);
            var documentsPrice = idealPrice * _documentsCostModifier * CalculateConditionModifier(stats.DocumentsConditionReal);

            return (ulong)(bodyPrice + enginePrice + chassisPrice + electricPrice + documentsPrice);
        }

        private float CalculateConditionModifier(float condition)
        {
            if (condition < 0.3) return condition * 0.25f;
            if (condition < 0.75f) return condition * 0.75f;

            return condition;
        }
    }
}
