using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The thing the camera follows (PlayerPawn)
    public float smoothSpeed = 0.125f;  // How smooth the follow is (smaller = smoother/slower)
    public Vector3 offset;         // Position offset (like pulling camera back a bit)

    void LateUpdate()
    {
        if (target == null)
        {
            return; // Do nothing if no target
        }

        // Desired position = target’s position + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move camera from current position to desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update camera position
        transform.position = smoothedPosition;
    }
}

