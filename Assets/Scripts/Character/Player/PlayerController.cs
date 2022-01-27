using UnityEngine;
using UnityEngine.InputSystem;
using EndlessRunner.ScriptableObjects.Events;
using EndlessRunner.Utils;
using EndlessRunner.Character.Player.Input.Keyboard;
using EndlessRunner.Character.Player.Input.Mobile;

namespace EndlessRunner.Character.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(RayDetector))]
    public sealed class PlayerController : MonoBehaviour 
    {
        private Rigidbody rb;
        private RayDetector checkGround;
        private Transform playerTransform;
        [SerializeField] private IntEvent onAddPizza = default;
        [SerializeField] private IntEvent onRemovePizza = default;
        [SerializeField] private GameEvent onPizzaDelivered = default;

        [Header("Player Settings")]
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private float moveSpeedHorizontal = 0.7f;
        [SerializeField] private float moveSpeedForward = 0.3f;
        [SerializeField] private float jumpForce = 12;
        private bool isGround = false;

        [Header("Line Settings")]
        [SerializeField] private int lineCurrent = 2;
        private const int lineTotal = 3;
        [SerializeField] private float distanceBetweenLines = 4;
        private float moveXPositionTarget = 0;

        // Animator Parameters
        private const string animatorParameterIsGround = "IsGround";
        private const string animatorParameterJumpTrigger = "Jump";
        private const string animatorParameterVelocityVertical = "VelocityVertical";


        [Header("Touch Settings")]
        [SerializeField] private float maximumTimeForValidateMovimentTouch = 0.5f;
        private Vector2 startTouchPosition;
        private Vector2 directionTouch;
        [SerializeField] private float distanceTouchHorizontal = 100;
        [SerializeField] private float distanceTouchVertical = 60;

        // Input
        private PlayerKeyboardInputAction playerKeyboardInput;
        private PlayerMobileInputAction playerMobileInput;

        private void OnEnable() 
        {
            playerKeyboardInput.Enable();
            playerMobileInput.Enable();
        }

        private void OnDisable() 
        {
            playerKeyboardInput.Disable();
            playerMobileInput.Disable();
        }

        private void Awake() 
        {
            playerKeyboardInput = new PlayerKeyboardInputAction();
            playerMobileInput = new PlayerMobileInputAction();
            playerTransform = this.transform;
            rb = GetComponent<Rigidbody>();
            checkGround = GetComponent<RayDetector>();
        }

        private void Start() 
        {
            playerMobileInput.Touch.TouchPress.started += ctx => StartTouch(ctx);
            playerMobileInput.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        }

        private void Update()
        {
            playerAnimator.SetFloat(animatorParameterVelocityVertical, rb.velocity.y);
            if(CanMoveLeftInput())
            {
                MoveLeft();
            }
            else if(CanMoveRightInput())
            {
                MoveRight();
            }

            if(CanJumpInput())
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            isGround = checkGround.collisionDetected;
            playerAnimator.SetBool(animatorParameterIsGround, isGround);
            MoveHorizontal();
            MoveToForward();
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            startTouchPosition = playerMobileInput.Touch.TouchPosition.ReadValue<Vector2>();
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            double duration = context.time - context.startTime;
            if(duration >= maximumTimeForValidateMovimentTouch) return;

            Vector2 endTouchPosition = playerMobileInput.Touch.TouchPosition.ReadValue<Vector2>();
            directionTouch = endTouchPosition - startTouchPosition;

            if(CanMoveLeftMobile())
            {
                MoveLeft();
            }
            else if(CanMoveRightMobile())
            {
                MoveRight();
            }
            else if(CanJumpMobile())
            {
                Jump();
            }

            directionTouch = Vector2.zero;
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

        private void MoveLeft()
        {
            if(CanMoveLeft())
            {
                lineCurrent -= 1;
                SetMovePositionTarget();
            }
        }

        private void MoveRight()
        {
            if(CanMoveRight())
            {
                lineCurrent += 1;
                SetMovePositionTarget();
            }
        }

        private void Jump()
        {
            if(CanJump())
            {
                playerAnimator.SetTrigger(animatorParameterJumpTrigger);
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }

        private bool CanMoveLeftMobile()
        {
            return directionTouch.x <= -distanceTouchHorizontal && Mathf.Abs(directionTouch.x) > directionTouch.y;
        }

        private bool CanMoveRightMobile()
        {
            return directionTouch.x >= distanceTouchHorizontal && directionTouch.x > directionTouch.y;
        }

        private bool CanJumpMobile()
        {
            return directionTouch.y >= distanceTouchVertical && directionTouch.y > directionTouch.x;
        }

        private bool CanMoveLeftInput()
        {
            return playerKeyboardInput.PlayerActions.MoveLeft.triggered;
        }

        private bool CanMoveRightInput()
        {
            return playerKeyboardInput.PlayerActions.MoveRight.triggered;
        }

        private bool CanJumpInput()
        {
            return playerKeyboardInput.PlayerActions.Jump.triggered;
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

        private void OnTriggerEnter(Collider other) 
        {
            if(other.CompareTag("pizza"))
            {
                onAddPizza.Raise(1);
                other.gameObject.SetActive(false);
            }

            if(other.CompareTag("cliente"))
            {
                onPizzaDelivered.Raise();
            }
        }
    }
}