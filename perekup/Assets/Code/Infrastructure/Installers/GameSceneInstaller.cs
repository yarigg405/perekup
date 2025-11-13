using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.EntryPoints;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    internal sealed class GameSceneInstaller : MonoInstaller
    {
        protected override void Install()
        {
            RegisterCommonServices();
            RegisterPlayerServices();
           

            Builder.RegisterEntryPoint<GameSceneEntryPoint>();
        }

        private void RegisterCommonServices()
        {
           
        }

        private void RegisterPlayerServices()
        {
            
        }
    }
}
