using VContainer;


namespace Assets.Code.Infrastructure.SaveLoad.Infrastructure
{
    internal interface ISaveLoader
    {
        void SaveGame(IGameRepository repository, IObjectResolver resolver);
        void LoadGame(IGameRepository repository, IObjectResolver resolver);
    }
}
