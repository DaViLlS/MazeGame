using UnityEngine;

namespace _Project.Character.Scripts.Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Character/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float jumpForce;
        
        public float WalkSpeed => walkSpeed;
        public float SprintSpeed => sprintSpeed;
        public float JumpForce => jumpForce;
    }
}