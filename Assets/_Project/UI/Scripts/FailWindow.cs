using System;
using _Project.UI.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.UI.Scripts
{
    public class FailWindow : Window
    {
        public event Action OnRestartClicked;
        
        [SerializeField] private Button restartButton;
        
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
            base.Show();
        }

        private void ClickRestart()
        {
            OnRestartClicked?.Invoke();
        }
    }
}