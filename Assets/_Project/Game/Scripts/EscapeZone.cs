using System;
using UnityEngine;

namespace _Project.Game.Scripts
{
    public class EscapeZone : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        public event Action OnEscaped;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                OnEscaped?.Invoke();
            }
        }
    }
}