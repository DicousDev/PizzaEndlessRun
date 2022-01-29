using UnityEngine;

namespace EndlessRunner.Utils
{
    public sealed class MoveForward : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 50;

        public void Move()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}