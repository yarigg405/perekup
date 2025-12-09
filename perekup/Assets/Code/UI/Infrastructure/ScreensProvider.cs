using VContainer;


namespace Assets.Code.UI.Infrastructure
{
    public sealed class ScreensProvider
    {
        private readonly IObjectResolver _objectResolver;

        public ScreensProvider(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public IScreen GetScreen<TScreen>() where TScreen : IScreen
        {
            return _objectResolver.Resolve<TScreen>();
        }
    }
}
