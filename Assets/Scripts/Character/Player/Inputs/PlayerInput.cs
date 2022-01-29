using UnityEngine;
using EndlessRunner.Interfaces.Movement;
using EndlessRunner.Interfaces.Jump;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Character.Player.Input
{
    public abstract class PlayerInput : MonoBehaviour
    {
        protected abstract bool CanMoveLeft();
        protected abstract bool CanMoveRight();
        protected abstract bool CanJump();
        private bool canJump = false;
        private IMovementLine movimentLine;
        private IJump playerJump;
        [SerializeField] private GameEvent onPlayerIsJump = default;

        protected virtual void Awake() 
        {
            movimentLine = GetComponent<IMovementLine>();
            playerJump = GetComponent<IJump>();
        }

        protected virtual void Update()
        {
            if(CanMoveLeft())
            {
                movimentLine.MoveToLineLeft();
            }
            else if(CanMoveRight())
            {
                movimentLine.MoveToLineRight();
            }

            if(CanJump())
            {
                canJump = true;
            }    
        }

        private void FixedUpdate() 
        {
            if(canJump)
            {
                onPlayerIsJump.Raise();
                canJump = false;
                playerJump.Jump();
            }
        }
    }
}