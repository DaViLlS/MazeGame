using UnityEngine;

namespace _Project.UI.Scripts.Core
{
    public abstract class Window : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Dispose();

        public virtual void Show()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            Cursor.visible = false;
            gameObject.SetActive(false);
        }
    }
}