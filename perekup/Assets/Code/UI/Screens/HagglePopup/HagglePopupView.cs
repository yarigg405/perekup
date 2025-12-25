using Assets.Code.UI.Elements.CarStatsPanel;
using Assets.Code.UI.Infrastructure;
using UnityEngine;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopupView : UIScreenView
    {
        [field: SerializeField] public CarStatsPanelView _carStatsPanel { get; private set; }

    }
}