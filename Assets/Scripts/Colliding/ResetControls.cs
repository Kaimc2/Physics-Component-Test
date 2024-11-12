using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ResetControls : MonoBehaviour
{
    [Header("Left Side")]
    public Rigidbody[] leftBlock;
    private Vector3[] leftBlockPosition;

    [Header("Right Side")]
    public Rigidbody[] rightBlock;
    private Vector3[] rightBlockPosition;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize the position arrays to match the block arrays
        leftBlockPosition = new Vector3[leftBlock.Length];
        rightBlockPosition = new Vector3[rightBlock.Length];

        // Save old block position
        for (int i = 0; i < leftBlock.Length; i++)
        {
            leftBlockPosition[i] = leftBlock[i].position;
            rightBlockPosition[i] = rightBlock[i].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Reset the block position
        for (int i = 0; i < leftBlock.Length; i++)
        {
            leftBlock[i].position = leftBlockPosition[i];
            rightBlock[i].position = rightBlockPosition[i];
        }
    }
}

