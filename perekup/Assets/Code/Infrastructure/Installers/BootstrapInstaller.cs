using Assets.Code.Characters;
using Assets.Code.Common.Time;
using Assets.Code.Gameplay;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.EntryPoints;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.SaveLoad;
using Assets.Code.Infrastructure.SaveLoad.Infrastructure;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Market;
using Assets.Code.Player;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    internal sealed class BootstrapInstaller : MonoInstaller
    {
        protected override void Install()
        {
            RegisterInfrastructureServices();
            RegisterPlayerServices();
            RegisterSaveLoaders();
            RegisterStates();
            RegisterFactories();
            RegisterGameplayServices();

            RegisterEntryPoint();
        }

        private void RegisterInfrastructureServices()
        {
            Builder.Register<UnityTimeService>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<GameRepository>(Lifetime.Transient).AsImplementedInterfaces();
            Builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<ScenesLoader>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterPlayerServices()
        {
            Builder.Register<PlayerCharacterProvider>(Lifetime.Singleton).AsSelf();
            Builder.Register<GameSettingsContainer>(Lifetime.Singleton).AsSelf();
            Builder.Register<PlayerMoneyStorage>(Lifetime.Singleton).AsSelf();
            Builder.Register<PlayerCarsStorage>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterSaveLoaders()
        {


            Builder.Register<SaveLoadMetaService>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterStates()
        {
            Builder.Register<BootstrapState>(Lifetime.Transient).AsSelf();
            Builder.Register<LoadGameState>(Lifetime.Transient).AsSelf();
            Builder.Register<EnterGameState>(Lifetime.Transient).AsSelf();
            Builder.Register<GameLoopState>(Lifetime.Transient).AsSelf();
        }

        private void RegisterFactories()
        {
            Builder.Register<CharacterFactory>(Lifetime.Singleton).AsSelf();
            Builder.Register<CarOrderGenerator>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterGameplayServices()
        {
            Builder.Register<RandomDiceService>(Lifetime.Singleton).AsSelf();
            Builder.Register<CarMarketService>(Lifetime.Singleton).AsSelf();
            Builder.Register<CharactersStorageService>(Lifetime.Singleton).AsSelf();
            Builder.Register<CarInspectionService>(Lifetime.Singleton).AsSelf();
            Builder.Register<CarPriceEstimateService>(Lifetime.Singleton).AsSelf();
            Builder.Register<HagglingService>(Lifetime.Singleton).AsSelf();
        }


        private void RegisterEntryPoint()
        {
            Builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
