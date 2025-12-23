using Assets.Code.Cars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yrr.UI.Elements;


namespace Assets.Code.UI.Elements.CarStatsPanel
{
    public sealed class CarStatsPanelView : MonoBehaviour
    {
        [SerializeField] private Image _carIcon;
        [SerializeField] private TextMeshProUGUI _carDescriptionTmp;

        [Header("Stats")]
        [SerializeField] private SmoothSlider _bodyKnownSlider;
        [SerializeField] private SmoothSlider _bodyRealSlider;

        [SerializeField] private SmoothSlider _engineKnownSlider;
        [SerializeField] private SmoothSlider _engineRealSlider;

        [SerializeField] private SmoothSlider _chassisKnownSlider;
        [SerializeField] private SmoothSlider _chassisRealSlider;

        [SerializeField] private SmoothSlider _electricKnownSlider;
        [SerializeField] private SmoothSlider _electricRealSlider;

        [SerializeField] private SmoothSlider _documentsKnownSlider;
        [SerializeField] private SmoothSlider _documentsRealSlider;



        public void SetIcon(Sprite icon)
        {
            _carIcon.sprite = icon;
        }

        public void SetDescription(string description)
        {
            _carDescriptionTmp.text = description;
        }

        public void InitStats(CarStats stats)
        {
            ////////
            _bodyKnownSlider.InitValue(0);
            _bodyKnownSlider.ChangeValue(stats.BodyConditionKnown);

            _bodyRealSlider.InitValue(0);
            _bodyRealSlider.ChangeValue(stats.BodyConditionReal);

            //////////
            _engineKnownSlider.InitValue(0);
            _engineKnownSlider.ChangeValue(stats.EngineCondidionKnown);

            _engineRealSlider.InitValue(0);
            _engineRealSlider.ChangeValue(stats.EngineCondidionReal);

            ////////////
            _chassisKnownSlider.InitValue(0);
            _chassisKnownSlider.ChangeValue(stats.ChassisConditionKnown);

            _chassisRealSlider.InitValue(0);
            _chassisRealSlider.ChangeValue(stats.ChassisConditionReal);

            /////////////
            _electricKnownSlider.InitValue(0);
            _electricKnownSlider.ChangeValue(stats.ElectricConditionKnown);

            _electricRealSlider.InitValue(0);
            _electricRealSlider.ChangeValue(stats.ElectricConditionReal);

            /////////////
            _documentsKnownSlider.InitValue(0);
            _documentsKnownSlider.ChangeValue(stats.DocumentsConditionKnown);

            _documentsRealSlider.InitValue(0);
            _documentsRealSlider.ChangeValue(stats.DocumentsConditionReal);
        }


        public void RefreshStats(CarStats stats)
        {
            _bodyKnownSlider.ChangeValue(stats.BodyConditionKnown);
            _bodyRealSlider.ChangeValue(stats.BodyConditionReal);

            _engineKnownSlider.ChangeValue(stats.EngineCondidionKnown);
            _engineRealSlider.ChangeValue(stats.EngineCondidionReal);

            _chassisKnownSlider.ChangeValue(stats.ChassisConditionKnown);
            _chassisRealSlider.ChangeValue(stats.ChassisConditionReal);

            _electricKnownSlider.ChangeValue(stats.ElectricConditionKnown);
            _electricRealSlider.ChangeValue(stats.ElectricConditionReal);

            _documentsKnownSlider.ChangeValue(stats.DocumentsConditionKnown);
            _documentsRealSlider.ChangeValue(stats.DocumentsConditionReal);
        }
    }
}
