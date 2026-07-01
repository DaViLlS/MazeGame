using System;
using _Project.Camera.Scripts;
using _Project.Core.AI.Scripts;
using _Project.Enemies.Scripts;
using UnityEngine;

namespace _Project.Character.Scripts
{
    public class CharacterController : MonoBehaviour, IVisible
    {
        public event Action OnDeath;
        
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Movement movement;
        [SerializeField] private Transform[] visiblePoints;
        
        Transform[] IVisible.VisiblePoints => visiblePoints;

        private void Start()
        {
            cameraController.Initialize();
            movement.Initialize();
        }

        private void OnDestroy()
        {
            movement.Dispose();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                OnDeath?.Invoke();
                return;
            }
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}