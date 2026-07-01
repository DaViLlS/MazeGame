using _Project.Core.Input.Scripts;
using UnityEngine;
using Zenject;
using CharacterController = _Project.Character.Scripts.CharacterController;

namespace _Project.Camera.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;

        [SerializeField] private CharacterController character;

        private bool _isInitialized;

        public void Initialize()
        {
            Cursor.lockState = CursorLockMode.Locked;

            _isInitialized = true;
        }

        private void Update()
        {
            if (!_isInitialized)
                return;
            
            transform.Rotate(Vector3.left, _inputHandler.MouseYAxis, Space.Self);
            character.transform.Rotate(Vector3.up, _inputHandler.MouseXAxis, Space.World);
        }
    }
}