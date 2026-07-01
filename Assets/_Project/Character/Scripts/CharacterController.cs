using System;
using _Project.Camera.Scripts;
using _Project.Core.AI.Scripts;
using _Project.Enemies.Scripts;
using UnityEngine;

namespace _Project.Character.Scripts
{
    public class CharacterController : MonoBehaviour, IVisible
    {
        private const string EscapeTag = "Escape";
        
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
                Debug.Log("Поражение");
                return;
            }

            if (other.CompareTag(EscapeTag))
            {
                Debug.Log("Победа");
            }
        }

        public GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}