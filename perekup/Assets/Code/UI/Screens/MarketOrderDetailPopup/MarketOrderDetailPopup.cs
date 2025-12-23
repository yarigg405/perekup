using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;
using VContainer;


namespace Assets.Code.UI.Screens
{
    public sealed class MarketOrderDetailPopup : IScreen
    {
        private readonly IScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Popups _screenRoot;

        private readonly MarkerOrderDetailPopupPresenter _presenter;

        public MarketOrderDetailPopup(IObjectResolver objectResolver,
            LayerUI_Popups screenRoot, IScreenViewsProvider viewsProvider)
        {
            _screenRoot = screenRoot;
            _viewsProvider = viewsProvider;

            _presenter = new(objectResolver);
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<MarketOrderDetailPopupView>();
            view.transform.SetParent(_screenRoot.transform);

            var order = (CarOrder)args;
            _presenter.Show(view, order);
        }

        void IScreen.Hide()
        {
            _presenter.Close();
        }
    }
}
