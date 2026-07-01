using UnityEngine;

namespace _Project.UI.Scripts.Core
{
    public abstract class HudElement : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Dispose();
    }
}