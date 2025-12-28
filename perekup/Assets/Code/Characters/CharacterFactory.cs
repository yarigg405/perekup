using Assets.Code.StaticData;
using UnityEngine;
using Yrr.Utils;


namespace Assets.Code.Characters
{
    public sealed class CharacterFactory
    {
        private readonly CharactersGenerationStorage _storage;

        private const float _chanceForGenderIsFemale = 0.38f;

        public CharacterFactory(CharactersGenerationStorage storage)
        {
            _storage = storage;
        }



        public Character GenerateRandomCharacter()
        {
            var character = new Character();
            character.Guid = System.Guid.NewGuid().ToString();

            var stats = GenerateRandomStats();
            var gender = Random.Range(0f, 1f) < _chanceForGenderIsFemale ?
                CharacterGender.Female :
                CharacterGender.Male;

            var name = GenerateNewName(gender);
            var iconIndex = gender == CharacterGender.Male ?
                _storage.MaleFaces.GetRandomIndex() :
                _storage.FemaleFaces.GetRandomIndex();

            character.Stats = stats;
            character.VisualName = name;
            character.Gender = gender;
            character.IconIndex = iconIndex;

            return character;
        }

        private int[] GenerateRandomStats()
        {
            int[] stats = new int[6];

            for (int i = 0; i < stats.Length; i++)
            {
                stats[i] = 6;
            }

            int statsPoint = 30;
            while (statsPoint > 0)
            {
                int index = stats.GetRandomIndex();
                if (stats[index] < 20)
                {
                    stats[index]++;
                    statsPoint--;
                }
            }

            return stats;
        }

        private string GenerateNewName(CharacterGender gender)
        {
            var firstName = gender == CharacterGender.Male ?
                _storage.MaleNames.GetRandomItem() :
                _storage.FemaleNames.GetRandomItem();

            var lastName = _storage.LastNames.GetRandomItem();

            return $"{firstName} {lastName}";
        }
    }
}
