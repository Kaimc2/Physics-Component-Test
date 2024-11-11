using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;
    public Transform targetTransform; // the object camera will follow
    public Transform cameraPivot; // the object camera use to pivot (look up and down)
    private Vector3 cameraFollowVelocity = Vector3.zero;
    
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 1;
    public float cameraPivotSpeed = 1;

    public float lookAngle; // camera looking up and down 
    public float pivotAngle; // camera looking left and right

    private void Awake()
    {
        targetTransform = FindObjectOfType<ThirdPersonController>().transform;
        inputManager = FindObjectOfType<InputManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        lookAngle += inputManager.cameraInputX * cameraLookSpeed * Time.deltaTime;
        pivotAngle -= inputManager.cameralInputY * cameraPivotSpeed * Time.deltaTime;

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);

        transform.rotation = targetRotation;
        cameraPivot.localRotation = targetRotation;
    }
}
