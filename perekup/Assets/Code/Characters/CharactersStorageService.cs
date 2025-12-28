using System.Collections.Generic;
using System.Linq;


namespace Assets.Code.Characters
{
    public sealed class CharactersStorageService
    {
        private readonly CharacterFactory _characterFactory;

        private readonly List<Character> _characters = new();

        public CharactersStorageService(CharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;

            for (int i = 0; i < 15; i++)
            {
                _characters.Add(_characterFactory.GenerateRandomCharacter());
            }
        }



        public IEnumerable<Character> GetAllCharacters() =>
            _characters;

        public Character GetCharacter(string characterGuid) =>
             _characters.First(x => x.Guid == characterGuid);
    }
}
