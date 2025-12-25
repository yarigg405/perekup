using Assets.Code.Player;
using System;
using VContainer.Unity;


namespace Assets.Code.UI.Elements.PlayerMoneyPlank
{
    public sealed class PlayerMoneyPlankPresenter : IStartable, IDisposable
    {
        private readonly PlayerMoneyStorage _storage;
        private readonly PlayerMoneyPlankView _view;

        public PlayerMoneyPlankPresenter(PlayerMoneyPlankView view,
            PlayerMoneyStorage storage)
        {
            _view = view;
            _storage = storage;
        }

        void IStartable.Start()
        {
            _storage.OnPlayerChanged += OnMoneyChanged;
            _view.SetupMoney(_storage.PlayerMoney);
        }

        void IDisposable.Dispose()
        {
            _storage.OnPlayerChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(ulong money)
        {
            _view.ChangeMoney(money);
        }
    }
}
