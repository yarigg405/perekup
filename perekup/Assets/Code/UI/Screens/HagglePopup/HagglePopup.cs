using Assets.Code.Market;
using Assets.Code.UI.Infrastructure;


namespace Assets.Code.UI.Screens
{
    public sealed class HagglePopup : IScreen
    {
        private readonly IScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Popups _screenRoot;
        private readonly HagglePopupPresenter _presenter;

        public HagglePopup(HagglePopupPresenter presenter, 
            LayerUI_Popups screenRoot, IScreenViewsProvider viewsProvider)
        {
            _presenter = presenter;
            _screenRoot = screenRoot;
            _viewsProvider = viewsProvider;
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<HagglePopupView>();
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
