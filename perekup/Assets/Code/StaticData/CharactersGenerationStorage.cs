using UnityEngine;


namespace Assets.Code.StaticData
{
    [CreateAssetMenu(fileName = "CharactersGenerationStorage", menuName = "ScriptableObjects/CharactersGenerationStorage", order = 51)]
    public sealed class CharactersGenerationStorage : ScriptableObject
    {
        [field: SerializeField] public Sprite[] MaleFaces;
        [field: SerializeField] public Sprite[] FemaleFaces;

        [Space]
        [TextArea]
        [SerializeField] private string _maleNames;
        [field: SerializeField] public string[] MaleNames { get; private set; }

        [Space]
        [TextArea]
        [SerializeField] private string _femaleNames;
        [field: SerializeField] public string[] FemaleNames { get; private set; }

        [Space]
        [TextArea]
        [SerializeField] private string _lastNames;
        [field: SerializeField] public string[] LastNames { get; private set; }


        [ContextMenu("RegenerateNames")]
        public void RegenerateNames()
        {
            MaleNames = _maleNames.Replace(" ", "").Split(",", System.StringSplitOptions.RemoveEmptyEntries);
            FemaleNames = _femaleNames.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
            LastNames = _lastNames.Split(",", System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
