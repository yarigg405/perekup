using Assets.Code.UI.Infrastructure;
using VContainer;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketScreen : IScreen
    {
        private readonly IScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Screens _screenRoot;
        private readonly MarketScreenPresenter _presenter;

        public MarketScreen(IScreenViewsProvider viewsProvider, LayerUI_Screens screenRoot,
            IObjectResolver objectResolver, MarketScreenPresenter presenter)
        {
            _viewsProvider = viewsProvider;
            _screenRoot = screenRoot;
            _presenter = presenter;
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<MarketScreenView>();
            view.transform.SetParent(_screenRoot.transform);
            _presenter.Show(view);
        }

        void IScreen.Hide()
        {
            _presenter.Hide();
        }
    }
}
