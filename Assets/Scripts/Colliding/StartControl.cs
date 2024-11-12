using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartControl : MonoBehaviour
{
    public float force = 9999f;

    [Header("Left Side")]
    public Rigidbody[] leftBlock;

    [Header("Right Side")]
    public Rigidbody[] rightBlock;

    private void OnTriggerEnter(Collider other) {
        for (int i = 0; i < leftBlock.Length; i++)
        {
            leftBlock[i].AddForce(Vector3.right * force);
            rightBlock[i].AddForce(Vector3.left * force);
        }
    } 
}
