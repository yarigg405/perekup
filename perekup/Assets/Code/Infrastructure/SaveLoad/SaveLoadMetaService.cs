using Assets.Code.Infrastructure.SaveLoad.Infrastructure;
using System.Collections.Generic;
using VContainer;


namespace Assets.Code.Infrastructure.SaveLoad
{
    internal sealed class SaveLoadMetaService : SaveLoadService<IMetaSaveLoader>
    {
        public SaveLoadMetaService(IEnumerable<IMetaSaveLoader> saveLoaders,
            IGameRepository gameRepository,
            IObjectResolver resolver)
            : base(saveLoaders, gameRepository, resolver) { }

        protected override string SavePath => "SaveDataMeta";
    }
}
