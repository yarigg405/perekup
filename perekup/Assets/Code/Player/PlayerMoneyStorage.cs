using System;


namespace Assets.Code.Player
{
    public sealed class PlayerMoneyStorage
    {
        public event Action<ulong> OnMoneyChanged;
        public event Action<ulong> OnMoneyEarned;
        public event Action<ulong> OnMoneySpent;

        public ulong PlayerMoney { get; private set; } = 1000;

        public void EarnMoney(ulong amount)
        {
            PlayerMoney += amount;
            OnMoneyEarned?.Invoke(amount);
            OnMoneyChanged?.Invoke(PlayerMoney);
        }

        public void SpentMoney(ulong amount)
        {
            PlayerMoney -= amount;
            OnMoneySpent?.Invoke(amount);
            OnMoneyChanged?.Invoke(PlayerMoney);
        }
    }
}
