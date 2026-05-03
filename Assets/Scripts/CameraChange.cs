using UnityEngine;
using Unity.Cinemachine;

public class CameraChange : MonoBehaviour
{
public CinemachineCamera zoneCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Priority 20 makes this camera active
            zoneCamera.Priority = 20;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Priority 10 makes it inactive compared to others
            zoneCamera.Priority = 10;
        }
    }
}
