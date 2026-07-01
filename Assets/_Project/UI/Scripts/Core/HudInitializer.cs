using UnityEngine;

namespace _Project.UI.Scripts.Core
{
    public class HudInitializer : MonoBehaviour
    {
        private HudElement[] _hudElements;
        
        private void Start()
        {
            _hudElements = GetComponentsInChildren<HudElement>();

            foreach (var hudElement in _hudElements)
            {
                hudElement.Initialize();
            }
        }

        private void OnDestroy()
        {
            foreach (var hudElement in _hudElements)
            {
                hudElement.Dispose();
            }
        }
    }
}