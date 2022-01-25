using UnityEngine;
using EndlessRunner.Utils;

namespace EndlessRunner.Character.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(RayDetector))]
    public sealed class PlayerController : MonoBehaviour 
    {
        private Rigidbody rb;
        private RayDetector checkGround;
        private Transform playerTransform;

        [Header("Player Settings")]
        [SerializeField] private float moveSpeedHorizontal = 0.7f;
        [SerializeField] private float moveSpeedForward = 0.3f;
        [SerializeField] private float jumpForce = 6;
        [SerializeField] private bool isGround;

        [Header("Line Settings")]
        [SerializeField] private int lineCurrent = 2;
        private int lineTotal = 3;
        [SerializeField] private float distanceBetweenLines = 4;
        private float moveXPositionTarget;

        private void Awake() 
        {
            playerTransform = this.transform;
            rb = GetComponent<Rigidbody>();
            checkGround = GetComponent<RayDetector>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.A) && CanMoveLeft())
            {
                lineCurrent -= 1;
                SetMovePositionTarget();
            }
            else if(Input.GetKeyDown(KeyCode.D) && CanMoveRight())
            {
                lineCurrent += 1;
                SetMovePositionTarget();
            }

            if(Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            isGround = checkGround.collisionDetected;
            MoveHorizontal();
            MoveToForward();
        }

        private void MoveToForward()
        {
            rb.MovePosition(rb.position + Vector3.forward * moveSpeedForward);
        }

        private void MoveHorizontal()
        {
            Vector3 playerPosition = playerTransform.position;
            playerPosition.x = moveXPositionTarget;
            Vector3 move = Vector3.MoveTowards(playerTransform.position, new Vector3(moveXPositionTarget, playerTransform.position.y, playerTransform.position.z), moveSpeedHorizontal);
            rb.MovePosition(move);
        }

        private void Jump()
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }

        private bool CanMoveLeft()
        {
            return lineCurrent > 1;
        }

        private bool CanMoveRight()
        {
            return lineCurrent < lineTotal;
        }

        private bool CanJump()
        {
            return isGround;
        }

        private void SetMovePositionTarget()
        {
            if(lineCurrent == 1)
            {
                moveXPositionTarget = -distanceBetweenLines;
            }
            else if(lineCurrent == 2)
            {
                moveXPositionTarget = 0;
            }
            else if(lineCurrent == 3)
            {
                moveXPositionTarget = distanceBetweenLines;
            }
        }
    }
}