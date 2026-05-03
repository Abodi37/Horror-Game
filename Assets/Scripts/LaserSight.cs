using UnityEngine;

public class LaserSight : MonoBehaviour
{
    private LineRenderer lr;
    public float maxDistance = 50f;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Set the start of the line to the gun tip
        lr.SetPosition(0, transform.position);

        RaycastHit hit;
        // Shoot an invisible ray forward
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // If it hits something, stop the laser at that point
            lr.SetPosition(1, hit.point);
        }
        else
        {
            // If it hits nothing, extend the laser into the distance
            lr.SetPosition(1, transform.position + (transform.forward * maxDistance));
        }
    }
}

