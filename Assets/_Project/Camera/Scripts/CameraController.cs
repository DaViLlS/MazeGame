using _Project.Core.Input.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Camera.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [Inject] private InputHandler _inputHandler;

        [SerializeField] private CharacterController character;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            transform.Rotate(Vector3.left, _inputHandler.MouseYAxis, Space.Self);
            character.transform.Rotate(Vector3.up, _inputHandler.MouseXAxis, Space.World);
        }
    }
}