using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate the camera rotation and set the rotation limits
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 50f);

        // Rotate the player to follow the mouse position
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera to smoothly rotate around the player
        transform.rotation = Quaternion.Euler(xRotation, playerBody.eulerAngles.y, 0);
    }
}
