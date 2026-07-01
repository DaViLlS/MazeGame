using _Project.Collectables.Scripts;
using UnityEngine;

namespace _Project.Character.Scripts
{
    public class Collector : MonoBehaviour
    {
        public int CollectablesCount { get; private set; }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ICollectable>(out var collectable))
            {
                collectable.Collect();
                
                CollectablesCount++;
            }
        }
    }
}