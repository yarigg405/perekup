using UnityEngine;


namespace Assets.Code.Market
{
    internal struct CarOrderGenerationPattern
    {
        public Vector2 BobyConditionMinMax;
        public Vector2 EngineConditionMinMax;
        public Vector2 ChassisConditionMinMax;
        public Vector2 ElectricConditionMinMax;
        public Vector2 DocumentsConditionMinMax;
        public float PriceModificator;
    }
}
