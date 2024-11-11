using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChainRenderer : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;
    public Vector3 offsets = new(2f, 0.2f, 2f);
    private new LineRenderer renderer;
    SpringJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<LineRenderer>();
        joint = GetComponent<SpringJoint>();
        renderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (joint.IsDestroyed())
        {
            Destroy(renderer);
        }
        else
        {
            renderer.SetPosition(0, objectA.position + offsets);
            renderer.SetPosition(1, objectB.position);
        }
    }
}
