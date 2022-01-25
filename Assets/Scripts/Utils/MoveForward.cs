using UnityEngine;


namespace EndlessRunner.Utils
{
    public sealed class MoveForward : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 50;

        public void Initialize(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public void Move()
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}