using System;
using UnityEngine;

namespace EndlessRunner.Spawner.Obstacles 
{
    [Serializable]
    public sealed class ObstaclePool
    {
        public string tag;
        public GameObject prefab;
    }
}