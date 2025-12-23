using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;
using VContainer;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketOrderDetailPopup : IScreen
    {
        private readonly ScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Popups _screenRoot;
        private readonly IObjectResolver _objectResolver;

        private MarkerOrderDetailPopupPresenter _presenter;

        public MarketOrderDetailPopup(IObjectResolver objectResolver, 
            LayerUI_Popups screenRoot, ScreenViewsProvider viewsProvider)
        {
            _objectResolver = objectResolver;
            _screenRoot = screenRoot;
            _viewsProvider = viewsProvider;
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<MarketOrderDetailPopupView>();
            view.transform.SetParent(_screenRoot.transform);

            var order = (CarOrder)args;
            _presenter = _objectResolver.Resolve<MarkerOrderDetailPopupPresenter>();
            _presenter.Show(view, order);
        }

        void IScreen.Hide()
        {
            _presenter.Close();
        }
    }
}
