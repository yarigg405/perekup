using Assets.Code.Cars;
using System;


namespace Assets.Code.Market
{
    [Serializable]
    public sealed class CarOrder
    {
        public string OrderGuid { get; set; }
        public string SellerId { get; set; }
        public CarStats Stats { get; set; }
        public ulong Price { get; set; }
        public float LocationDistance { get; set; }
        public int OrderDurationLifetimeDays { get; set; }


        public CarOrder Copy()
        {
            return new CarOrder
            {
                OrderGuid = OrderGuid,
                Price = Price,
                SellerId = SellerId,
                LocationDistance = LocationDistance,
                OrderDurationLifetimeDays = OrderDurationLifetimeDays,
                Stats = Stats.Copy()
            };
        }
    }
}