using UnityEngine;
using EndlessRunner.Interfaces.Detection;
using EndlessRunner.ScriptableObjects.Events;

namespace EndlessRunner.Character.Player.Animation
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private GameEvent onPlayerIsJump = default;
        private Rigidbody rb;
        private IDetector checkGround;
        private bool isGround = false;
        private const string animatorParameterIsGround = "IsGround";
        private const string animatorParameterJumpTrigger = "Jump";
        private const string animatorParameterVelocityVertical = "VelocityVertical";

        private void OnEnable() 
        {
            onPlayerIsJump.onGameListener += JumpTrigger;
        }

        private void OnDisable() 
        {
            onPlayerIsJump.onGameListener -= JumpTrigger;
        }

        private void Awake() 
        {
            rb = GetComponent<Rigidbody>();
            checkGround = GetComponent<IDetector>();
        }

        private void Update()
        {
            isGround = checkGround.GetDetection();
            playerAnimator.SetBool(animatorParameterIsGround, isGround);
            playerAnimator.SetFloat(animatorParameterVelocityVertical, rb.velocity.y);
        }

        private void JumpTrigger()
        {
            playerAnimator.SetTrigger(animatorParameterJumpTrigger);
        }
    }
}
