using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 1200f);
    } 
}
