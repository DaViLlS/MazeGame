using _Project.Character.Scripts.Data;
using _Project.Core.Input.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Character.Scripts
{
    public class Movement : MonoBehaviour
    {
        [Inject] private CharacterConfig _characterConfig;
        [Inject] private InputHandler _inputHandler;
        
        [SerializeField] private Rigidbody rb;
        
        private bool _isInitialized;
        
        private float _currentSpeed;
        private bool _isGrounded;

        public void Initialize()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
            
            _isGrounded = true;
            _currentSpeed = _characterConfig.WalkSpeed;

            _inputHandler.OnSprintPerformed += MakeSprint;
            _inputHandler.OnSprintCancelled += MakeWalk;

            _inputHandler.OnJumpPerformed += Jump;
            
            _isInitialized = true;
        }

        public void Dispose()
        {
            _isInitialized = false;
            
            _inputHandler.OnSprintPerformed -= MakeSprint;
            _inputHandler.OnSprintCancelled -= MakeWalk;
            
            _inputHandler.OnJumpPerformed -= Jump;
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                _isGrounded = true;
        }

        private void FixedUpdate()
        {
            if (!_isInitialized)
                return;
            
            var moveDirection = transform.forward * _inputHandler.MovementVector.y + transform.right * _inputHandler.MovementVector.x;
            rb.linearVelocity = moveDirection * _currentSpeed + new Vector3(0f, rb.linearVelocity.y, 0f);
        }

        private void MakeSprint()
        {
            _currentSpeed = _characterConfig.SprintSpeed;
        }
        
        private void MakeWalk()
        {
            _currentSpeed = _characterConfig.WalkSpeed;
        }
        
        private void Jump()
        {
            if (!_isGrounded)
                return;
            
            _isGrounded = false;
            rb.AddForce(Vector3.up * _characterConfig.JumpForce, ForceMode.Impulse);
        }
    }
}