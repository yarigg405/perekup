using Assets.Code.Cars;
using Assets.Code.Characters;
using Assets.Code.StaticData;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.Market
{
    public sealed class CarOrderGenerator
    {
        private readonly StaticDataService _staticData;
        private readonly CharactersStorageService _charactersStorage;
        private readonly CarPriceEstimateService _carAppraiseService;

        private readonly RandomizerByWeight<string> _weightetCarIds = new();
        private readonly RandomizerByWeight<CarOrderGenerationPattern> _weightetPatterns = new();


        //Configs
        private readonly Vector2 _priceModificatoMinMax = new(0.7f, 1.2f);


        public CarOrderGenerator(StaticDataService staticData,
            CharactersStorageService charactersStorage,
            CarPriceEstimateService carAppraiseService)
        {
            _staticData = staticData;
            _charactersStorage = charactersStorage;
            _carAppraiseService = carAppraiseService;

            LoadCars();
            LoadPatterns();
        }

        private void LoadCars()
        {
            var carsIds = _staticData.GetAllCarIds();
            foreach (var id in carsIds)
            {
                var config = _staticData.GetCar(id);
                _weightetCarIds.AddVariant(id, config.RandomWeight);
            }
        }

        private void LoadPatterns()
        {
            //common used car
            _weightetPatterns.AddVariant(
                new CarOrderGenerationPattern
                {
                    BobyConditionMinMax = new(0.5f, 0.75f),
                    EngineConditionMinMax = new(0.5f, 0.75f),
                    ChassisConditionMinMax = new(0.5f, 0.75f),
                    ElectricConditionMinMax = new(0.5f, 0.75f),
                    DocumentsConditionMinMax = new(0.8f, 1f),
                    PriceModificator = 1f,
                }, 15f);

            //good condition car
            _weightetPatterns.AddVariant(
                 new CarOrderGenerationPattern
                 {
                     BobyConditionMinMax = new(0.65f, 0.9f),
                     EngineConditionMinMax = new(0.65f, 0.9f),
                     ChassisConditionMinMax = new(0.65f, 0.9f),
                     ElectricConditionMinMax = new(0.65f, 0.9f),
                     DocumentsConditionMinMax = new(0.8f, 1f),
                     PriceModificator = 1.1f,
                 }, 9f);

            //after accident, poor condition
            _weightetPatterns.AddVariant(
                new CarOrderGenerationPattern
                {
                    BobyConditionMinMax = new(0.1f, 0.35f),
                    EngineConditionMinMax = new(0.1f, 0.65f),
                    ChassisConditionMinMax = new(0.2f, 0.65f),
                    ElectricConditionMinMax = new(0.3f, 0.75f),
                    DocumentsConditionMinMax = new(0.8f, 1f),
                    PriceModificator = 0.8f,
                }, 6f);

            //after drowning
            _weightetPatterns.AddVariant(
                new CarOrderGenerationPattern
                {
                    BobyConditionMinMax = new(0.25f, 0.75f),
                    EngineConditionMinMax = new(0.35f, 0.75f),
                    ChassisConditionMinMax = new(0.5f, 0.75f),
                    ElectricConditionMinMax = new(0.1f, 0.3f),
                    DocumentsConditionMinMax = new(0.8f, 1f),
                    PriceModificator = 0.9f,
                }, 2f);

            //without documents
            _weightetPatterns.AddVariant(
                new CarOrderGenerationPattern
                {
                    BobyConditionMinMax = new(0.45f, 0.8f),
                    EngineConditionMinMax = new(0.45f, 0.8f),
                    ChassisConditionMinMax = new(0.45f, 0.8f),
                    ElectricConditionMinMax = new(0.45f, 0.8f),
                    DocumentsConditionMinMax = new(0f, 0.0f),
                    PriceModificator = 0.7f,
                }, 2f);

            //only documents
            _weightetPatterns.AddVariant(
                new CarOrderGenerationPattern
                {
                    BobyConditionMinMax = new(0f, 0f),
                    EngineConditionMinMax = new(0f, 0f),
                    ChassisConditionMinMax = new(0f, 0f),
                    ElectricConditionMinMax = new(0f, 0f),
                    DocumentsConditionMinMax = new(1f, 1f),
                    PriceModificator = 1.6f,
                }, 1f);
        }


        public CarOrder GenerateRandomOrder()
        {
            var carOrder = new CarOrder();
            carOrder.OrderGuid = System.Guid.NewGuid().ToString();
            var seller = _charactersStorage.GetAllCharacters().GetRandomItem();
            carOrder.SellerId = seller.Guid;

            var randomCarId = _weightetCarIds.GetRandom();
            var pattern = _weightetPatterns.GetRandom();
            var stats = GenerateOrderStats(randomCarId, seller, pattern);
            carOrder.Stats = stats;

            carOrder.Price = CalculatePrice(stats, seller, pattern);
            carOrder.LocationDistance = Random.Range(10, 300);
            carOrder.OrderDurationLifetimeDays = 30;

            return carOrder;
        }

        private CarStats GenerateOrderStats(string CarId, Character seller, CarOrderGenerationPattern pattern)
        {
            var realBody = pattern.BobyConditionMinMax.GetRandomValue();
            var knownBody = CalculateKnownStat(realBody, seller);

            var realEngine = pattern.EngineConditionMinMax.GetRandomValue();
            var knownEngine = CalculateKnownStat(realEngine, seller);

            var realChassis = pattern.ChassisConditionMinMax.GetRandomValue();
            var knownChassis = CalculateKnownStat(realChassis, seller);

            var realElectric = pattern.ElectricConditionMinMax.GetRandomValue();
            var knownElectric = CalculateKnownStat(realElectric, seller);

            var realDocuments = pattern.DocumentsConditionMinMax.GetRandomValue();
            var knownDocuments = CalculateKnownStat(realDocuments, seller);

            return new()
            {
                CarId = CarId,

                BodyConditionReal = realBody,
                BodyConditionKnown = knownBody,

                EngineCondidionReal = realEngine,
                EngineCondidionKnown = knownEngine,

                ChassisConditionReal = realChassis,
                ChassisConditionKnown = knownChassis,

                ElectricConditionReal = realElectric,
                ElectricConditionKnown = knownElectric,

                DocumentsConditionReal = realDocuments,
                DocumentsConditionKnown = knownDocuments,
            };
        }

        private float CalculateKnownStat(float origin, Character seller)
        {
            if (origin == 0) return 0;
            if (origin == 1) return 1;

            var agilityBonus = seller.GetStatBonus(CharacterStats.Agility);
            var techBonus = seller.GetStatBonus(CharacterStats.Intelligence);
            if (agilityBonus < 0) return origin;

            var modifier = (agilityBonus + techBonus + 1) * 0.05f;
            var result = origin + modifier;
            return Mathf.Clamp(result, 0, 1);
        }

        private ulong CalculatePrice(CarStats stats, Character seller, CarOrderGenerationPattern pattern)
        {
            var realPrice = _carAppraiseService.CalculateRealPrice(stats);
            var knownPrice = _carAppraiseService.CalculateKnownPrice(stats);

            var orderPrice = _priceModificatoMinMax.GetRandomValue() * pattern.PriceModificator * knownPrice;
            return (ulong)orderPrice;
        }
    }
}
