using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    private void Update()
    {
        FollowTarget();
    }

    // Следование камеры за объектом по оси Z
    private void FollowTarget()
    {
        var cameraPosition = transform.position;
        
        var targetPosition = new Vector3(cameraPosition.x, cameraPosition.y, targetTransform.position.z);
        
        transform.position = targetPosition;
    }
}
