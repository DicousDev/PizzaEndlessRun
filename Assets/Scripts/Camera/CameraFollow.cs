using UnityEngine;

namespace EndlessRunner.Camera
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Vector3 startDirection;

        private void Awake() 
        {
            cameraTransform = this.transform;    
        }

        private void Start()
        {
            startDirection = target.position - cameraTransform.position;
        }

        private void LateUpdate()
        {
            Vector3 newPosition = target.position - startDirection; 
            transform.position = new Vector3(0, newPosition.y, newPosition.z);
        }
    }
}