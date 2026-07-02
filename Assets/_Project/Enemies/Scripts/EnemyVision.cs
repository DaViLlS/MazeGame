using System;
using _Project.Core.AI.Scripts;
using UnityEngine;
using CharacterController = _Project.Character.Scripts.CharacterController;

namespace _Project.Enemies.Scripts
{
    public class EnemyVision : MonoBehaviour
    {
        public event Action OnCharacterDetected;
        public event Action OnCharacterLost;
        
        [SerializeField] private Transform currentEyes;
        [SerializeField] private float visibleAngle;
        [SerializeField] private float visibleDistance;
        [SerializeField] private LayerMask visibleMask;

        private bool _isInitialized;
        private CharacterController _character;

        private bool _characterDetected;
        private bool _characterLost;

        public void Initialize(CharacterController character)
        {
            _character = character;
            
            _isInitialized = true;
        }
        
        private void FixedUpdate()
        {
            if (!_isInitialized)
                return;
            
            if (IsCharacterVisible() && !_characterDetected)
            {
                _characterDetected = true;
                _characterLost = false;
                OnCharacterDetected?.Invoke();
            }
            else if (!_characterLost)
            {
                _characterDetected = false;
                _characterLost = true;
                OnCharacterLost?.Invoke();
            }
        }
        
        private bool IsCharacterVisible()
        {
            return ViewUtility.IsVisibleUnit(_character, currentEyes, visibleAngle, visibleDistance, visibleMask);
        }
    }
}