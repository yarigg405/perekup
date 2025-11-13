using Assets.Code.Cars;
using Assets.Code.Infrastructure.DI;
using Assets.Code.StaticData;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.Installers
{
    internal sealed class StaticDataInstaller : MonoInstaller
    {
        [SerializeField] private CarConfigSO[] _carConfigs;


        protected override void Install()
        {
            Builder.Register<StaticDataService>(Lifetime.Singleton).AsSelf()
                .WithParameter(_carConfigs);
        }
    }
}
