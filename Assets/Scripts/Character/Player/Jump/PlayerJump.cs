using UnityEngine;
using EndlessRunner.Interfaces.Jump;
using EndlessRunner.Interfaces.Detection;

namespace EndlessRunner.Character.Player.Jump
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerJump : MonoBehaviour , IJump
    {
        private Rigidbody rb;
        private IDetector checkGround;
        [SerializeField] private float jumpForce = 12;
        private bool isGround = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            checkGround = GetComponent<IDetector>();
        }

        private void Update() 
        {
            isGround = checkGround.GetDetection();
        }

        public void Jump()
        {
            if(CanJump())
            {
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }

        private bool CanJump()
        {
            return isGround;
        }
    }
}