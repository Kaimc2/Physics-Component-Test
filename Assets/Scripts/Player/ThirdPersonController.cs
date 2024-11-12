using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
