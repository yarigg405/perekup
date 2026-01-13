using Assets.Code.UI.Infrastructure;


namespace Assets.Code.UI.Screens
{
    public sealed class GarageScreen : IScreen
    {
        private readonly IScreenViewsProvider _viewsProvider;
        private readonly LayerUI_Screens _screenRoot;
        private readonly GarageScreenPresenter _presenter;


        public GarageScreen(IScreenViewsProvider viewsProvider, LayerUI_Screens screenRoot, GarageScreenPresenter presenter)
        {
            _viewsProvider = viewsProvider;
            _screenRoot = screenRoot;
            _presenter = presenter;
        }

        void IScreen.Show(object args)
        {
            var view = _viewsProvider.GetView<GarageScreenView>();
            view.transform.SetParent(_screenRoot.transform);
            view.transform.SetAsLastSibling();
            _presenter.Show(view);
        }

        void IScreen.Hide()
        {
            _presenter.Hide();
        }
    }
}