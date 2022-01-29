using UnityEngine;

namespace EndlessRunner.Character.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMovementForward : MonoBehaviour
    {
        private Rigidbody rb;
        [SerializeField] private float moveSpeed = 0.3f;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate() => Move();

        private void Move()
        {
            rb.MovePosition(rb.position + Vector3.forward * moveSpeed);
        }
    }
}