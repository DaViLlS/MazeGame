using _Project.Collectables.Scripts;
using _Project.UI.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using CharacterController = _Project.Character.Scripts.CharacterController;

namespace _Project.Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private GameConfig _gameConfig;
        [Inject] private CollectablesCounter _collectablesCounter;
        
        [SerializeField] private CharacterController characterController;
        [SerializeField] private EscapeZone escapeZone;
        [SerializeField] private VictoryWindow victoryWindow;
        [SerializeField] private FailWindow failWindow;

        private void Start()
        {
            characterController.OnDeath += OpenFailWindow;
            _collectablesCounter.OnCollectablesChanged += CheckVictory;
            failWindow.OnRestartClicked += RestartGame;
            victoryWindow.OnRestartClicked += RestartGame;
        }

        private void OnDestroy()
        {
            characterController.OnDeath -= OpenFailWindow;
            _collectablesCounter.OnCollectablesChanged -= CheckVictory;
            failWindow.OnRestartClicked -= RestartGame;
            victoryWindow.OnRestartClicked -= RestartGame;
        }

        private void CheckVictory()
        {
            if (_collectablesCounter.CollectablesCount >= _gameConfig.DiamondsToCompleteLevel)
            {
                escapeZone.OnEscaped += OpenVictoryWindow;
                escapeZone.gameObject.SetActive(true);
            }
        }
        
        private void OpenFailWindow()
        {
            failWindow.Show();
            
            PauseGame();
        }

        private void OpenVictoryWindow()
        {
            escapeZone.OnEscaped -= OpenVictoryWindow;
            victoryWindow.Show();
            
            PauseGame();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
        }
        
        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}