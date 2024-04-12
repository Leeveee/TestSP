using Components;
using Factory;
using Generator;
using Services.SaveLoadService;
using Services.SceneLoaderService;
using Zenject;

namespace Core
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDestroyer>()
                .To<Destroyer>()
                .FromInstance(GetComponentInChildren<Destroyer>())
                .AsSingle();

            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IItemFactory>().To<ItemFactory>().AsSingle();
            Container.Bind<ISceneLoaderService>().To<SceneLoader>().AsSingle();
            Container.Bind<IItemsGenerator>().To<ItemsGenerator>().AsSingle();
        }
    }
}