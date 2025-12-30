using Assets.Code.Characters;


namespace Assets.Code.Gameplay
{
    public sealed class HagglingService
    {
        private readonly RandomDiceService _diceService;

        public HagglingService(RandomDiceService diceService)
        {
            _diceService = diceService;
        }

        internal int GetStartAcceptingSellingModificator(Character character)
        {
            return _diceService.GetRandomD20() - character.GetStatBonus(CharacterStats.Constitution);
        }

        internal int ResultOfConvincing(Character convictionFrom, Character convictionTo)
        {
            var result1 = _diceService.GetRandomD20() + convictionFrom.GetStatBonus(CharacterStats.Strength);
            var result2 = _diceService.GetRandomD20() + convictionTo.GetStatBonus(CharacterStats.Constitution);

            return result1 - result2;
        }

        internal int ResultOfLie(Character lieFrom, Character lieTo)
        {
            var result1 = _diceService.GetRandomD20() + lieFrom.GetStatBonus(CharacterStats.Agility);
            var result2 = _diceService.GetRandomD20() + lieTo.GetStatBonus(CharacterStats.Intelligence);

            return result1 - result2;
        }

        internal int ResultOfCharming(Character charmFrom, Character charmTo)
        {
            var result1 = _diceService.GetRandomD20() + charmFrom.GetStatBonus(CharacterStats.Charisma);
            var result2 = _diceService.GetRandomD20() + charmTo.GetStatBonus(CharacterStats.Wisdom);

            return result1 - result2;
        }
    }
}
