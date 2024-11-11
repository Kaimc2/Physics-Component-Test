using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController: MonoBehaviour
{
    public CharacterController player;
    public Transform thirdPersonCharacter;
    public Transform dotUI;

    [Header("Player Properties")]
    public float speed = 5f;
    private readonly float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Ground Properties")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Walk();
        Sprint();
        Jump();

        // Switch to third person character
        if (Input.GetKeyDown(KeyCode.F5))
        {
            player.gameObject.SetActive(false);
            thirdPersonCharacter.gameObject.SetActive(true);
            dotUI.gameObject.SetActive(false);
        }
    }

    public void Walk()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = (transform.right * x + transform.forward * z).normalized;
        player.Move(speed * Time.deltaTime * movement);
    }

    public void Sprint()
    {
        // Handle sprinting
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
    }

    public void Jump()
    {
        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        player.Move(velocity * Time.deltaTime);
    }
}
