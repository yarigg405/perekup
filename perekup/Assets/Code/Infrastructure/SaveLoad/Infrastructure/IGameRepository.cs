namespace Assets.Code.Infrastructure.SaveLoad.Infrastructure
{
    internal interface IGameRepository
    {
        void SaveState(string savePath);

        void LoadState(string savePath);

        void SetData<T>(T value);

        T GetData<T>();
    }
}
