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
            
        }

        public void ClickRestart()
        {
            OnRestartClicked?.Invoke();
        }
    }
}