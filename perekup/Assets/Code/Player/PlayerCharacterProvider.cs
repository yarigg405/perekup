using Assets.Code.Characters;


namespace Assets.Code.Player
{
    public sealed class PlayerCharacterProvider
    {
        private readonly Character _playerCharacter;

        public Character PlayerCharacter => _playerCharacter;

        public PlayerCharacterProvider()
        {
            _playerCharacter = CreatePlayerCharacter();
        }

        private Character CreatePlayerCharacter()
        {
            return new()
            {
                Guid = "Player",
                Stats = new[] {9, 9, 9, 11, 16, 16 },

                VisualName = "Clarence Bronco",
                Gender = CharacterGender.Male,
                IconIndex = 10,
            };
        }
    }
}
