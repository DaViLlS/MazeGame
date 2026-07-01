using _Project.Character.Scripts.Data;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private CharacterConfig characterConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(characterConfig).AsSingle().NonLazy();
        }
    }
}