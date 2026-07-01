using UnityEngine;

namespace _Project.UI.Scripts.Core
{
    public abstract class Window : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Dispose();

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}