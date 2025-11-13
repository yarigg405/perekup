using System;


namespace Assets.Code.Cars
{
    [Serializable]
    public sealed class CarStats
    {
        public string CarId { get; set; }

        //real Condition
        public int BodyConditionReal { get; set; }
        public int EngineCondidion { get; set; }
        public int ChassisConditionReal { get; set; }
        public int ElectricConditionReal { get; set; }


        //known Condition
        public int BodyConditionKnown { get; set; }
        public int EngineCondidionKnown { get; set; }
        public int ChassinConditionKnown { get; set; }
        public int ElectricConditionKnown { get; set; }
    }
}
