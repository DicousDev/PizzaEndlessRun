using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner.Spawner.Platform 
{
    public sealed class SpawnPlatform : MonoBehaviour
    {
        [SerializeField] private GameObject platformPrefab;
        [SerializeField] private Transform target;
        [SerializeField] private int totalPlatform = 5;
        private List<GameObject> platforms = new List<GameObject>();
        [SerializeField] private float distanceBetweenPlatforms = 24;
        [SerializeField] private float depthInitial = 44;
        private Transform firstPlatform;
        private Transform lastPlatform;
        private Transform parent;
        
        private void Awake()
        {
            GameObject parentGameObject = new GameObject("SpawnPlatform");
            parent = parentGameObject.transform;
        }

        private void Start() => InitializePlatforms();

        private void Update()
        {
            if(CanRepositionFirstPlatform())
            {
                RepositionFirstPlatformToEnd();
            }
        }

        private void InitializePlatforms()
        {
            for(int i = 0; i < totalPlatform; i++)
            {
                Vector3 spawnPosition = new Vector3(0, 0, depthInitial + distanceBetweenPlatforms * (i + 1));
                Spawn(spawnPosition);
            }

            SetFirstPlatform();
            SetLastPlatform();
        }

        private void Spawn(Vector3 spawnPosition)
        {
            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platform.transform.SetParent(parent, false);
            platforms.Add(platform);
        }

        private bool CanRepositionFirstPlatform()
        {
            return target.position.z >= firstPlatform.position.z;
        }

        private void RepositionFirstPlatformToEnd()
        {
            platforms.Remove(firstPlatform.gameObject);
            platforms.Add(firstPlatform.gameObject);

            float lastPlatformPositionZ = lastPlatform.position.z;
            firstPlatform.position = new Vector3(0, 0, lastPlatformPositionZ + distanceBetweenPlatforms);

            SetFirstPlatform();
            SetLastPlatform();
        }

        private void SetFirstPlatform()
        {
            firstPlatform = platforms.First().transform;
        }

        private void SetLastPlatform()
        {
            lastPlatform = platforms.Last().transform;
        }
    }
}