using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public RectTransform tooltip;
    HingeJoint joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    private void OnMouseOver()
    {
        tooltip.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        tooltip.gameObject.SetActive(false);
    }

    private void OnMouseDrag()
    {
        joint.useMotor = true;
    }

    private void OnMouseUp()
    {
        joint.useMotor = false;
    }
}
