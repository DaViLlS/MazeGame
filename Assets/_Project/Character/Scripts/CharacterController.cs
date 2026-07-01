using _Project.Camera.Scripts;
using UnityEngine;

namespace _Project.Character.Scripts
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Movement movement;

        private void Start()
        {
            cameraController.Initialize();
            movement.Initialize();
        }

        private void OnDestroy()
        {
            movement.Dispose();
        }
    }
}