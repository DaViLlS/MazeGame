using UnityEngine;

namespace _Project.Core.AI.Scripts
{
    public interface IVisible
    {
        public Transform[] VisiblePoints { get; }

        public GameObject GetGameObject();
    }
}