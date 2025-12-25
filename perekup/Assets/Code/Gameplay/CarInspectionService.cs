using Assets.Code.Cars;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assets.Code.Gameplay
{
    public sealed class CarInspectionService
    {

        public void Inspect(CarStats stats)
        {
            stats.BodyConditionKnown = stats.BodyConditionReal;
            stats.EngineCondidionKnown = stats.EngineCondidionReal;
            stats.ChassisConditionKnown = stats.ChassisConditionReal;
            stats.ElectricConditionKnown = stats.ElectricConditionReal;
            stats.DocumentsConditionKnown = stats.DocumentsConditionReal;
        }
    }
}
