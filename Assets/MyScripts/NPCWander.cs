
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace MyGame
{
    public class NPCWander : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform player;
        public float radius = 10f;
        public float detectRange = 7f;
        private Vector3 spawnPosition;
        private float waitTimer = 0f;
        public float pauseTime = 2f;


        void Start()
        {
            spawnPosition = transform.position;
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectRange)
            {
                agent.SetDestination(player.position);
            }
            else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                Wander();
            }
        }

        Vector3 GetRandomPosition()
        {
            Vector3 randomPositon = Random.insideUnitSphere * radius;
            randomPositon += spawnPosition;

            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPositon, out hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return spawnPosition;
        }

        void Wander()
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer > pauseTime)
                {
                    agent.SetDestination(GetRandomPosition());
                    waitTimer = 0f;
                }
            }
        }
    }
}