using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    public Transform firstPersonCharacter;
    CameraManager cameraManager;
    public Transform dotUI;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();

        // Switch to first person character
        if (Input.GetKeyDown(KeyCode.F5))
        {
            playerLocomotion.gameObject.SetActive(false);
            firstPersonCharacter.gameObject.SetActive(true);
            dotUI.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
    }
}
