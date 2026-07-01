using _Project.Collectables.Scripts;
using Zenject;

namespace _Project.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CollectablesCounter>().AsSingle().NonLazy();
        }
    }
}