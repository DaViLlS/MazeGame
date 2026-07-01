using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Core.Input.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        public event Action OnJumpPerformed;
        public event Action OnSprintPerformed;
        public event Action OnSprintCancelled;

        private PlayerInputActions _inputActions;
        private float _mouseXAxis;
        private float _mouseYAxis;

        public float MouseXAxis => _mouseXAxis;
        public float MouseYAxis => _mouseYAxis;
        public Vector2 MovementVector => _inputActions.Player.Move.ReadValue<Vector2>();

        private void Start()
        {
            Cursor.visible = false;
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();

            _inputActions.Player.Jump.performed += JumpPerformed;
            _inputActions.Player.Sprint.performed += ShiftPerformed;
            _inputActions.Player.Sprint.canceled += ShiftCancelled;
        }

        private void Update()
        {
            _mouseXAxis = UnityEngine.Input.GetAxis("Mouse X");
            _mouseYAxis = UnityEngine.Input.GetAxis("Mouse Y");
        }

        private void JumpPerformed(InputAction.CallbackContext context)
        {
            OnJumpPerformed?.Invoke();
        }

        private void ShiftPerformed(InputAction.CallbackContext context)
        {
            OnSprintPerformed?.Invoke();
        }

        private void ShiftCancelled(InputAction.CallbackContext context)
        {
            OnSprintCancelled?.Invoke();
        }
    }
}