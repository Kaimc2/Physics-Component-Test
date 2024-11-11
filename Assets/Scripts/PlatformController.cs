using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform[] waypointPaths;
    public float speed = 2f;
    private int waypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float elapsedTime;
    private float timeToWaypoint;

    private void Start()
    {
        TargetNextWaypoint();
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;
        transform.SetPositionAndRotation(
            Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage), 
            Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage)
        );

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPaths[waypointIndex];
        waypointIndex = waypointIndex == waypointPaths.Length - 1 ? 0 : waypointIndex += 1;
        targetWaypoint = waypointPaths[waypointIndex];

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player on platform");
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player off platform");
            other.transform.SetParent(null);
        }
    }
}
