using System;
using UnityEngine;


namespace Assets.Code.Characters
{
    [Serializable]
    public sealed class Character
    {
        public string Guid;
        public int[] Stats = new int[6];
        public string VisualName;
        public CharacterGender Gender;
        public int IconIndex;

        public int GetStat(CharacterStats statName)
        {
            return Stats[(int)statName];
        }

        public int GetStatBonus(CharacterStats statName)
        {
            var value = Stats[(int)statName];
            return GetStatBonus(value);
        }

        private int GetStatBonus(int statValue)
        {
            var modificator = (int)Mathf.Floor((statValue - 10) / 2f);
            return modificator;
        }
    }

    [Serializable]
    public enum CharacterGender
    {
        Male,
        Female,
    }
}
