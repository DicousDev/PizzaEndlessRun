using UnityEngine;
using UnityEngine.InputSystem;

namespace EndlessRunner.Character.Player.Input.Mobile
{
    public sealed class PlayerMobileInput : PlayerInput
    {
        #if UNITY_ANDROID
        private PlayerMobileInputAction playerMobileAction;
        [SerializeField] private float maximumTimeForValidateMovimentTouch = 0.5f;
        private Vector2 startTouchPosition;
        private Vector2 directionTouch;
        [SerializeField] private float distanceTouchHorizontal = 100;
        [SerializeField] private float distanceTouchVertical = 60;

        private void OnEnable() => playerMobileAction.Enable();

        private void OnDisable() => playerMobileAction.Disable();

        protected override void Awake()
        {
            base.Awake();
            playerMobileAction = new PlayerMobileInputAction();
        }

        private void Start() 
        {
            playerMobileAction.Touch.TouchPress.started += ctx => StartTouch(ctx);
            playerMobileAction.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        }

        protected override void Update()
        {
            base.Update();
            directionTouch = Vector2.zero;
        }

        protected override bool CanMoveLeft()
        {
            return directionTouch.x <= -distanceTouchHorizontal && Mathf.Abs(directionTouch.x) > directionTouch.y;
        }

        protected override bool CanMoveRight()
        {
            return directionTouch.x >= distanceTouchHorizontal && directionTouch.x > directionTouch.y;
        }

        protected override bool CanJump()
        {
            return directionTouch.y >= distanceTouchVertical && directionTouch.y > directionTouch.x;
        }

        private void StartTouch(InputAction.CallbackContext context)
        {
            startTouchPosition = playerMobileAction.Touch.TouchPosition.ReadValue<Vector2>();
        }

        private void EndTouch(InputAction.CallbackContext context)
        {
            double duration = context.time - context.startTime;
            if(duration >= maximumTimeForValidateMovimentTouch) return;

            Vector2 endTouchPosition = playerMobileAction.Touch.TouchPosition.ReadValue<Vector2>();
            directionTouch = endTouchPosition - startTouchPosition;
        }

        #endif
    }
}
