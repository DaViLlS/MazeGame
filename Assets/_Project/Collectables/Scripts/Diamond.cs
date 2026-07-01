using UnityEngine;

namespace _Project.Collectables.Scripts
{
    public class Diamond : MonoBehaviour, ICollectable
    {
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}