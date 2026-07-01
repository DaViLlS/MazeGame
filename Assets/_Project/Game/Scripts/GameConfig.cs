using UnityEngine;

namespace _Project.Game.Scripts
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private int diamondsToCompleteLevel;
        
        public int DiamondsToCompleteLevel => diamondsToCompleteLevel;
    }
}