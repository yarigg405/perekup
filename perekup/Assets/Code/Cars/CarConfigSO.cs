using UnityEngine;


namespace Assets.Code.Cars
{
    [CreateAssetMenu(fileName = "CarConfigSO", menuName = "ScriptableObjects/CarConfigSO", order = 51)]
    public sealed class CarConfigSO : ScriptableObject
    {
        [field: SerializeField] public string CarId { get; private set; }
        [field: SerializeField] public string CarBrandName { get; private set; }
        [field: SerializeField] public string CarModelName { get; private set; }
        [field: SerializeField] public int Year { get; private set; }
        [field: SerializeField] public Sprite CarIcon { get; private set; }
        [field: SerializeField] public Vector2 PriceMinMax { get; private set; }

        [field: SerializeField] public string VisualName { get; private set; }


        private void OnValidate()
        {
            VisualName = $"{CarBrandName} {CarModelName} {Year}";
        }
    }
}