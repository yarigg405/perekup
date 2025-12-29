using UnityEngine;


namespace Assets.Code.Gameplay
{
    public sealed class RandomDiceService
    {
        public int GetRandomD20()
        {
            return Random.Range(1, 21);
        }
    }
}
