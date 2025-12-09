using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;
using VContainer;


namespace Assets.Code.UI.Screens.MarketScreen
{
    public sealed class MarketScreen : IScreen
    {        
        private readonly ScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Screens _screenRoot;
        private readonly IObjectResolver _objectResolver;

        private MarketScreenPresenter _presenter;

        public MarketScreen(ScreenViewsProvider viewsProvider, LayerUI_Screens screenRoot, 
            IObjectResolver objectResolver)
        {
            _viewsProvider = viewsProvider;
            _screenRoot = screenRoot;
            _objectResolver = objectResolver;
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<MarketScreenView>();
            view.transform.SetParent(_screenRoot.transform);

            _presenter =_objectResolver.Resolve<MarketScreenPresenter>();
            _presenter.Show(view);
        }

        void IScreen.Hide()
        {
            
        }
    }
}
