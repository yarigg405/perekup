using System;


namespace Assets.Code.Cars
{
    [Serializable]
    public sealed class CarStats
    {
        public string CarId { get; set; }

        //real Condition
        public float BodyConditionReal { get; set; }
        public float EngineCondidionReal { get; set; }
        public float ChassisConditionReal { get; set; }
        public float ElectricConditionReal { get; set; }
        public float DocumentsConditionReal { get; set; }


        //known Condition
        public float BodyConditionKnown { get; set; }
        public float EngineCondidionKnown { get; set; }
        public float ChassisConditionKnown { get; set; }
        public float ElectricConditionKnown { get; set; }
        public float DocumentsConditionKnown { get; set; }
    }
}
