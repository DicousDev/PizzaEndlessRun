using UnityEngine;
using EndlessRunner.Utils;

namespace EndlessRunner.Car
{
    [RequireComponent(typeof(MoveForward))]
    [RequireComponent(typeof(RayDetector))]
    public sealed class Car : MonoBehaviour
    {
        private MoveForward move;
        private RayDetector detectorCollision;
        private bool isCollisionInFront = false;

        private void OnEnable() 
        {
            detectorCollision.enabled = true;
        }

        private void Awake()
        {
            move = GetComponent<MoveForward>();
            detectorCollision = GetComponent<RayDetector>();       
        }

        private void Update()
        {
            isCollisionInFront = detectorCollision.collisionDetected;
            if(isCollisionInFront)
            {
                detectorCollision.enabled = false;
            }
            else
            {
                move.Move();
            }
        }
    }
}