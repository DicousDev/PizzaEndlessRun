using System.Collections.Generic;
using UnityEngine;
using EndlessRunner.Utils;

namespace EndlessRunner.Spawner.Obstacles 
{
    public sealed class SpawnObstacles : MonoBehaviour
    {
        private LineMovement lineMovement;
        [SerializeField] private ObstaclePool[] obstaclesPool;
        private Dictionary<string, List<GameObject>> obstaclesDictionary = new Dictionary<string, List<GameObject>>();
        [SerializeField] private float distanceToSpawn = 50;
        private Vector3 distanceWalking;
        [SerializeField] private float maxDistanceWalkingToSpawn = 50;
        [SerializeField] private Transform target;
        [SerializeField] private LayerMask checkItemLayer;
        private Transform parent;

        private void Awake() 
        {
            lineMovement = new LineMovement();
            GameObject parentGameObject = new GameObject("SpawnObstacles");
            parent = parentGameObject.transform;
        }

        private void Start() => InitializePooling();

        private void Update()
        {
            CheckDistanceToSpawnObstacles();
            CheckAllObstaclesToDisable();
        }

        private void InitializePooling()
        {
            foreach(ObstaclePool pool in obstaclesPool)
            {
                obstaclesDictionary.Add(pool.tag, new List<GameObject>());
            }
        }

        private void CheckDistanceToSpawnObstacles()
        {
            Vector3 distance = target.position - distanceWalking;
            if(distance.magnitude >= maxDistanceWalkingToSpawn)
            {
                distanceWalking = target.position;
                SpawnRandomObstacle();
            }
        }

        private void CheckAllObstaclesToDisable()
        {
            foreach(ObstaclePool pool in obstaclesPool)
            {
                List<GameObject> obstaclesList = obstaclesDictionary[pool.tag];

                foreach(GameObject obstacle in obstaclesList)
                {
                    if(obstacle.transform.position.z <= target.position.z - 10)
                    {
                        obstacle.gameObject.SetActive(false);
                    }
                }
            }
        }

        private void SpawnRandomObstacle()
        {
            Vector3 spawnPosition = CalculateSpawnPosition();

            if(HasObjectInPosition(spawnPosition))
                return;

            ObstaclePool pool = GetRandomObstaclePool();
            spawnPosition.y = pool.prefab.transform.position.y;

            List<GameObject> obstacles = GetAllObstaclesDisabled(pool.tag);
            if(obstacles.Count > 0)
            {
                GameObject obstacleDisabled = obstacles[0];
                ReuseObstacles(obstacleDisabled, spawnPosition);
            }
            else
            {
                SpawnObstacle(pool, spawnPosition);
            }
        }

        private void ReuseObstacles(GameObject obstacleDisabled, Vector3 newPosition)
        {
            obstacleDisabled.transform.position = newPosition;
            obstacleDisabled.SetActive(true);
        }

        private List<GameObject> GetAllObstaclesDisabled(string tag)
        {
            List<GameObject> obstaclesDisabled = new List<GameObject>();
            if(!this.obstaclesDictionary.ContainsKey(tag))
                return obstaclesDisabled;


            List<GameObject> obstacles = obstaclesDictionary[tag];
            foreach(GameObject obstacle in obstacles)
            {
                if(obstacle.activeInHierarchy)
                    continue;

                obstaclesDisabled.Add(obstacle);
            }

            return obstaclesDisabled;
        }

        private void SpawnObstacle(ObstaclePool obstacle, Vector3 spawnPosition)
        {
            GameObject prefab = obstacle.prefab;
            GameObject newObstacle = Instantiate(prefab, spawnPosition, prefab.transform.rotation);
            newObstacle.transform.SetParent(parent, false);
            string tag = obstacle.tag;
            obstaclesDictionary[tag].Add(newObstacle);
        }

        private ObstaclePool GetRandomObstaclePool()
        {
            int randomObstacle = GetRandomObstaclesValue();
            return obstaclesPool[randomObstacle];
        }

        private int GetRandomObstaclesValue()
        {
            int random = Random.Range(0, obstaclesPool.Length);
            return random;
        }

        private Vector3 CalculateSpawnPosition()
        {
            lineMovement.RandomLinePosition();
            Vector3 position = new Vector3(lineMovement.linePositionCurrent, 1, target.position.z + distanceToSpawn);
            return position;
        }

        private bool HasObjectInPosition(Vector3 position)
        {
            Collider[] itens = Physics.OverlapSphere(position, 2, checkItemLayer);
            return itens.Length > 0;
        }
    }
}