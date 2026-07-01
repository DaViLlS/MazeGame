using _Project.Core.Input.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputHandler inputHandler;

        public override void InstallBindings()
        {
            Container.BindInstance(inputHandler).AsSingle().NonLazy();
        }
    }
}