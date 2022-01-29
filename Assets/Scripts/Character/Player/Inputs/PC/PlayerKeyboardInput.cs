namespace EndlessRunner.Character.Player.Input.Keyboard
{
    public sealed class PlayerKeyboardInput : PlayerInput
    {
        #if UNITY_EDITOR
        private PlayerKeyboardInputAction keyboardInputAction;

        private void OnEnable() => keyboardInputAction.Enable();

        private void OnDisable() => keyboardInputAction.Disable();

        protected override void Awake()
        {
            base.Awake();
            keyboardInputAction = new PlayerKeyboardInputAction();
        }

        protected override bool CanMoveLeft()
        {
            return keyboardInputAction.PlayerActions.MoveLeft.triggered;
        }

        protected override bool CanMoveRight()
        {
            return keyboardInputAction.PlayerActions.MoveRight.triggered;
        }

        protected override bool CanJump()
        {
            return keyboardInputAction.PlayerActions.Jump.triggered;
        }

        #endif
    }
}
