using UnityEngine;
using UnityEngine.AI;
using CharacterController = _Project.Character.Scripts.CharacterController;

namespace _Project.Enemies.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CharacterController character;
        [SerializeField] private EnemyVision enemyVision;
        [SerializeField] private NavMeshAgent agent;
        [Space]
        [SerializeField] private float distanceToPoint;
        [SerializeField] private Transform[] waypoints;

        private bool _characterDetected;
        private int _currentPointIndex;

        private void Awake()
        {
            if (character == null)
                character = FindAnyObjectByType<CharacterController>();
            
            enemyVision.Initialize(character);
            enemyVision.OnCharacterDetected += StartChasingCharacter;
        }

        private void OnDestroy()
        {
            enemyVision.OnCharacterDetected -= StartChasingCharacter;
        }

        private void Update()
        {
            if (_characterDetected)
            {
                agent.destination = character.transform.position;
            }
            else
            {
                Patrol();
            }
        }

        private void Patrol()
        {
            agent.SetDestination(waypoints[_currentPointIndex].position);
    
            if ((transform.position - waypoints[_currentPointIndex].position).sqrMagnitude < distanceToPoint)
            {
                SetNewRandomPoint();
            }
        }
        
        private void SetNewRandomPoint()
        {
            var differentWay = false;

            while (!differentWay)
            {
                var randomIndex = Random.Range(0, waypoints.Length - 1);

                if (waypoints[randomIndex] == waypoints[_currentPointIndex])
                    continue;
                
                _currentPointIndex = randomIndex;
                differentWay = true;
            }
        }

        private void StartChasingCharacter()
        {
            _characterDetected = true;
        }
    }
}