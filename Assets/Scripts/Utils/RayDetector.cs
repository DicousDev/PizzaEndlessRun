using UnityEngine;
using EndlessRunner.Interfaces.Detection;

namespace EndlessRunner.Utils
{
    public class RayDetector : MonoBehaviour , IDetector 
    {
        private enum DirectionState {Forward, Down}
        [SerializeField] private DirectionState directionState;
        [SerializeField] private Transform checkPoint;
        [SerializeField] private float distance = 3;
        [SerializeField] private bool directionLocal = false;
        [SerializeField] private LayerMask layerMask;
        public bool collisionDetected = false;
        private Vector3 directionRay;
        [SerializeField] private float sphereRadius = 1;
        [SerializeField] private Color rayColor = Color.red;

        void Awake() 
        {
            if(directionLocal) return;

            if(directionState == DirectionState.Down)
            {
                directionRay = Vector3.down;
            }
            else if(directionState == DirectionState.Forward)
            {
                directionRay = Vector3.forward;
            }
        }

        private void FixedUpdate()
        {
            if(directionLocal)
            {
                if(directionState == DirectionState.Down)
                {
                    collisionDetected = Physics.Raycast(checkPoint.position, -transform.up, distance, layerMask);
                }
                else if(directionState == DirectionState.Forward)
                {
                    collisionDetected = Physics.Raycast(checkPoint.position, transform.forward, distance, layerMask);
                }
            }
            else 
            {
                collisionDetected = Physics.Raycast(checkPoint.position, directionRay, distance, layerMask);
            }
        }

        public bool GetDetection()
        {
            return collisionDetected;
        }

        private void OnDrawGizmos() 
        {
            if(checkPoint)
            {
                Gizmos.color = rayColor;
                Gizmos.DrawSphere(checkPoint.position, sphereRadius);

                if(directionLocal)
                {
                    if(directionState == DirectionState.Down)
                    {
                        Gizmos.DrawRay(checkPoint.position, -transform.up * distance);                    
                    }
                    else if(directionState == DirectionState.Forward)
                    {
                        Gizmos.DrawRay(checkPoint.position, transform.forward * distance);                    
                    }
                }
                else
                {
                    Gizmos.DrawRay(checkPoint.position, directionRay * distance);
                }
            }
        }
    }
}