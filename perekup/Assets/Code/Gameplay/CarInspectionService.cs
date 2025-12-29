using Assets.Code.Cars;
using Assets.Code.Characters;
using UnityEngine;


namespace Assets.Code.Gameplay
{
    public sealed class CarInspectionService
    {
        private readonly RandomDiceService _randomDiceService;

        public CarInspectionService(RandomDiceService randomDiceService)
        {
            _randomDiceService = randomDiceService;
        }

        public void Inspect(CarStats stats, Character inspector)
        {
            var bodyResult = CalculateResult(inspector);
            var engineResult = CalculateResult(inspector);
            var chassisResult = CalculateResult(inspector);
            var electricResult = CalculateResult(inspector);
            var documentsResult = CalculateResult(inspector);

            stats.BodyConditionKnown = Mathf.Max(stats.BodyConditionReal, stats.BodyConditionKnown - bodyResult);
            stats.EngineCondidionKnown = Mathf.Max(stats.EngineCondidionReal, stats.EngineCondidionKnown - engineResult);
            stats.ChassisConditionKnown = Mathf.Max(stats.ChassisConditionReal, stats.ChassisConditionKnown - chassisResult);
            stats.ElectricConditionKnown = Mathf.Max(stats.ElectricConditionReal, stats.ElectricConditionKnown - electricResult);
            stats.DocumentsConditionKnown = Mathf.Max(stats.DocumentsConditionReal, stats.DocumentsConditionKnown - documentsResult);
        }

        private float CalculateResult(Character inspector)
        {
            float result =
                _randomDiceService.GetRandomD20() +
                inspector.GetStatBonus(CharacterStats.Wisdom);

            return result / 100f;
        }
    }
}
