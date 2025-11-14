using Assets.Code.Cars;
using Assets.Code.Characters;
using System;


namespace Assets.Code.Market
{
    [Serializable]
    public sealed class CarOrder
    {
        public ulong Price { get; set; }
        public CarStats Stats { get; set; }
        public Character Seller { get; set; }
        public float LocationDistance { get; set; }
        public int OrderDurationLifetimeDays { get; set; }
    }
}