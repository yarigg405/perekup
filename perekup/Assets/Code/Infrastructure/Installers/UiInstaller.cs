using Assets.Code.Infrastructure.DI;
using Assets.Code.UI.Elements;
using Assets.Code.UI.Elements.PlayerMoneyPlank;
using Assets.Code.UI.Infrastructure;
using Assets.Code.UI.LoadingScreens;
using Assets.Code.UI.Screens;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.Installers
{
    internal sealed class UiInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoadingScreen _sceneLoadingScreen;
        [SerializeField] private LayerUI_Screens _layerScreen;
        [SerializeField] private LayerUI_HUD _layerOverlay;
        [SerializeField] private LayerUI_Popups _layerPopups;

        [SerializeField ] private PlayerMoneyPlankView _playerMoneyPlankView;

        protected override void Install()
        {
            Builder.RegisterInstance(_sceneLoadingScreen).AsSelf();
            Builder.RegisterInstance(_layerScreen).AsSelf();
            Builder.RegisterInstance(_layerOverlay).AsSelf();
            Builder.RegisterInstance(_layerPopups).AsSelf();

            Builder.Register<ScreensProvider>(Lifetime.Transient).AsImplementedInterfaces();
            Builder.Register<ScreenViewsProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<UIManager>(Lifetime.Singleton);

            RegisterScreens();
            RegisterUiElements();
        }

        private void RegisterScreens()
        {
            Builder.Register<MarketScreen>(Lifetime.Singleton);
            Builder.Register<MarketScreenPresenter>(Lifetime.Transient);

            Builder.Register<MarketOrderDetailPopup>(Lifetime.Singleton);
            Builder.Register<MarkerOrderDetailPopupPresenter>(Lifetime.Transient);

            Builder.Register<HagglePopup>(Lifetime.Singleton);
            Builder.Register<HagglePopupPresenter>(Lifetime.Transient);

            Builder.Register<GarageScreen>(Lifetime.Singleton);
            Builder.Register<GarageScreenPresenter>(Lifetime.Transient);
        }

        private void RegisterUiElements()
        {
            Builder.RegisterInstance(_playerMoneyPlankView).AsSelf();
            Builder.Register<PlayerMoneyPlankPresenter>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
