using UnityEngine;

namespace _Project.UI.Scripts.Core
{
    public class WindowsInitializer : MonoBehaviour
    {
        private Window[] _windows;
        
        private void Start()
        {
            _windows = GetComponentsInChildren<Window>();

            foreach (var window in _windows)
            {
                window.Initialize();
            }
        }

        private void OnDestroy()
        {
            foreach (var window in _windows)
            {
                window.Dispose();
            }
        }
    }
}