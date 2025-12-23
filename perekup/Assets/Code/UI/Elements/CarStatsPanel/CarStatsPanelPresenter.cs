using Assets.Code.Cars;
using Assets.Code.StaticData;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assets.Code.UI.Elements.CarStatsPanel
{
    internal sealed class CarStatsPanelPresenter
    {
        private readonly StaticDataService _staticData;

        private CarStats _stats;

        public CarStatsPanelPresenter(StaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void Show(CarStats stats)
        {
            _stats = stats;

        }

        public void Refresh()
        {

        }
    }
}
