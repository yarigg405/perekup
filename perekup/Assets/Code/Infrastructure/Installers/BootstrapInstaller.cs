using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.EntryPoints;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.SaveLoad.Infrastructure;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    internal sealed class BootstrapInstaller : MonoInstaller
    {
        protected override void Install()
        {

            RegisterStaticData();
            RegisterInfrastructureServices();
            RegisterSaveLoaders();
            RegisterStates();
            RegisterFactories();

            RegisterEntryPoint();
        }

        private void RegisterStaticData()
        {

        }

        private void RegisterInfrastructureServices()
        {
            Builder.Register<GameRepository>(Lifetime.Transient).AsImplementedInterfaces();
            Builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            Builder.Register<ScenesLoader>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterSaveLoaders()
        {

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
        }

        private void RegisterEntryPoint()
        {
            Builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
