using UnityEngine;

namespace _Project.Collectables.Scripts
{
    public class Diamond : MonoBehaviour, ICollectable
    {
        [Header("Парение")]
        [SerializeField] private float floatAmplitude = 0.5f;
        [SerializeField] private float floatFrequency = 1f;
    
        [Header("Вращение")]
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private Vector3 rotationAxis = Vector3.up;
    
        private Vector3 _startPosition;
    
        private void Start()
        {
            _startPosition = transform.position;
        }
    
        private void Update()
        {
            FloatUpAndDown();
            RotateDiamond();
        }
        
        public void Collect()
        {
            Destroy(gameObject);
        }
    
        private void FloatUpAndDown()
        {
            var newY = _startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        
            transform.position = new Vector3(
                _startPosition.x,
                newY,
                _startPosition.z
            );
        }

        private void RotateDiamond()
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}