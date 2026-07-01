using _Project.Collectables.Scripts;
using UnityEngine;
using Zenject;

namespace _Project.Character.Scripts
{
    public class Collector : MonoBehaviour
    {
        [Inject] private CollectablesCounter _collectablesCounter;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ICollectable>(out var collectable))
            {
                collectable.Collect();
                
                _collectablesCounter.IncCollectablesCount();
            }
        }
    }
}