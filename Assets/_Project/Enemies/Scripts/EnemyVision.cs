using System;
using _Project.Core.AI.Scripts;
using UnityEngine;
using CharacterController = _Project.Character.Scripts.CharacterController;

namespace _Project.Enemies.Scripts
{
    public class EnemyVision : MonoBehaviour
    {
        public event Action OnCharacterDetected;
        
        [SerializeField] private Transform currentEyes;
        [SerializeField] private float visibleAngle;
        [SerializeField] private float visibleDistance;
        [SerializeField] private LayerMask visibleMask;

        private bool _isInitialized;
        private CharacterController _character;

        public void Initialize(CharacterController character)
        {
            _character = character;
            
            _isInitialized = true;
        }
        
        private void FixedUpdate()
        {
            if (!_isInitialized)
                return;
            
            if (IsCharacterVisible())
            {
                OnCharacterDetected?.Invoke();
            }
        }
        
        private bool IsCharacterVisible()
        {
            return ViewUtility.IsVisibleUnit(_character, currentEyes, visibleAngle, visibleDistance, visibleMask);
        }
    }
}