using System;


namespace Assets.Code.Cars
{
    [Serializable]
    public sealed class CarStats
    {
        public string CarId { get; set; }

        // real condition
        public float BodyConditionReal { get; set; }
        public float EngineCondidionReal { get; set; }
        public float ChassisConditionReal { get; set; }
        public float ElectricConditionReal { get; set; }
        public float DocumentsConditionReal { get; set; }

        // known condition
        public float BodyConditionKnown { get; set; }
        public float EngineCondidionKnown { get; set; }
        public float ChassisConditionKnown { get; set; }
        public float ElectricConditionKnown { get; set; }
        public float DocumentsConditionKnown { get; set; }

        public CarStats Copy()
        {
            return new CarStats
            {
                CarId = CarId,

                BodyConditionReal = BodyConditionReal,
                EngineCondidionReal = EngineCondidionReal,
                ChassisConditionReal = ChassisConditionReal,
                ElectricConditionReal = ElectricConditionReal,
                DocumentsConditionReal = DocumentsConditionReal,

                BodyConditionKnown = BodyConditionKnown,
                EngineCondidionKnown = EngineCondidionKnown,
                ChassisConditionKnown = ChassisConditionKnown,
                ElectricConditionKnown = ElectricConditionKnown,
                DocumentsConditionKnown = DocumentsConditionKnown
            };
        }
    }

}
