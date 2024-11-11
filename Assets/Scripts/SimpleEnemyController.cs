using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;

public class SimpleEnemyController : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    public Light spotLight;

    [Header("Properties")]
    public float lookRadius = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spotLight = GetComponentInChildren<Light>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (distance <= lookRadius)
        {
            spotLight.color = Color.red;
            agent.SetDestination(target.position);
        }
        else
        {
            spotLight.color = Color.yellow;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
