using Assets.Code.Market;
using Assets.Code.Player;


namespace Assets.Code.Gameplay
{
    public sealed class CarBuyingService
    {
        private readonly PlayerCarsStorage _playerCarsStorage;
        private readonly PlayerMoneyStorage _playerMoneyStorage;
        private readonly CarMarketService _carMarketService;

        public CarBuyingService(PlayerCarsStorage playerCarsStorage, 
            PlayerMoneyStorage playerMoneyStorage, CarMarketService carMarketService)
        {
            _playerCarsStorage = playerCarsStorage;
            _playerMoneyStorage = playerMoneyStorage;
            _carMarketService = carMarketService;
        }

        public bool TryBuyCar(CarOrder carOrder, ulong buyingPrice)
        {
            if (buyingPrice > _playerMoneyStorage.PlayerMoney)
                return false;

            _playerMoneyStorage.SpentMoney(buyingPrice);
            _carMarketService.RemoveCarOrderFromDataBase(carOrder);
            _playerCarsStorage.AddCarToStorage(carOrder, buyingPrice);  
            return true;
        }
    }
}
