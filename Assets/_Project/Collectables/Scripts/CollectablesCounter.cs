using System;

namespace _Project.Collectables.Scripts
{
    public class CollectablesCounter
    {
        public event Action OnCollectablesChanged;
            
        public int CollectablesCount { get; private set; }

        public void IncCollectablesCount()
        {
            CollectablesCount++;
            
            OnCollectablesChanged?.Invoke();
        }
    }
}