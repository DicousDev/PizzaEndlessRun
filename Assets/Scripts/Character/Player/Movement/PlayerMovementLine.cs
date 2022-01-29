using UnityEngine;
using EndlessRunner.Interfaces.Movement;
using EndlessRunner.Utils;

namespace EndlessRunner.Character.Player.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerMovementLine : MonoBehaviour , IMovementLine
    {
        private Rigidbody rb;
        private Transform playerTransform;
        private LineMovement line;
        [SerializeField] private int lineStart = 1;
        [SerializeField] private float moveSpeed = 0.7f;
        private Vector3 targetPosition;

        private void Awake()
        {
            line = new LineMovement(lineStart);
            playerTransform = this.transform;
            rb = GetComponent<Rigidbody>();
        }

        private void Start() => SetTargetPosition();

        private void FixedUpdate() => MoveHorizontal();

        public void MoveToLineLeft() => line.MoveLeft();

        public void MoveToLineRight() => line.MoveRight();

        private void MoveHorizontal()
        {            
            SetTargetPosition();
            Vector3 move = Vector3.MoveTowards(playerTransform.position, targetPosition, moveSpeed);
            move.y = rb.position.y;
            move.z = rb.position.z;
            rb.MovePosition(move);
        }

        private void SetTargetPosition()
        {
            targetPosition = playerTransform.position;
            targetPosition.x = line.linePositionCurrent;
        }
    }
}