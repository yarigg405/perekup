using Assets.Code.Infrastructure.DI;
using Assets.Code.UI;
using Assets.Yrr.UI.UI_System;
using UnityEngine;
using VContainer;
using Yrr.UI;
using Yrr.UI.Infrastructure;


namespace Assets.Code.Infrastructure.Installers
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private Transform _screensRoot;

        protected override void Install()
        {
            var screens = _screensRoot.GetComponentsInChildren<IUIScreen>(true);
            var supplier = new ScreensSupplier(screens);
            var uiManager = new UIManager(supplier);

            foreach (var screen in screens)
            {
                screen.SetupUiManager(uiManager);
                screen.Hide();
            }

            Builder.RegisterInstance(uiManager).AsSelf().AsImplementedInterfaces();

            uiManager.Show<GameMainScreen>();
        }
    }
}