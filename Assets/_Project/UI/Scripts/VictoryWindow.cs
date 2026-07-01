using System;
using _Project.Collectables.Scripts;
using _Project.Game.Scripts;
using _Project.UI.Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.UI.Scripts
{
    public class VictoryWindow : Window
    {
        public event Action OnRestartClicked;
        
        [Inject] private GameConfig _gameConfig;
        [Inject] private CollectablesCounter _collectablesCounter;

        [SerializeField] private Button restartButton;
        [SerializeField] private TMP_Text diamondsCount;
        
        public override void Initialize()
        {
            
        }
        
        public override void Dispose()
        {
            restartButton.onClick.RemoveAllListeners();
        }

        public override void Show()
        {
            restartButton.onClick.AddListener(ClickRestart);
            diamondsCount.text = _collectablesCounter.CollectablesCount + "/" + _gameConfig.DiamondsToCompleteLevel;
            
            base.Show();
        }
        
        private void ClickRestart()
        {
            OnRestartClicked?.Invoke();
        }
    }
}