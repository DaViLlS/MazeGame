using _Project.Collectables.Scripts;
using _Project.Game.Scripts;
using _Project.UI.Scripts.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.UI.Scripts
{
    public class DiamondsCounter : HudElement
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private CollectablesCounter _collectablesCounter;
        
        [SerializeField] private TMP_Text diamondsCount;
        
        public override void Initialize()
        {
            diamondsCount.text = _collectablesCounter.CollectablesCount + "/" + _gameConfig.DiamondsToCompleteLevel;
            
            _collectablesCounter.OnCollectablesChanged += UpdateView;
        }

        public override void Dispose()
        {
            _collectablesCounter.OnCollectablesChanged -= UpdateView;
        }
        
        private void UpdateView()
        {
            diamondsCount.text = _collectablesCounter.CollectablesCount + "/" + _gameConfig.DiamondsToCompleteLevel;
        }
    }
}