using _Project.Character.Scripts.Data;
using _Project.Game.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private CharacterConfig characterConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(gameConfig).AsSingle().NonLazy();
            Container.BindInstance(characterConfig).AsSingle().NonLazy();
        }
    }
}