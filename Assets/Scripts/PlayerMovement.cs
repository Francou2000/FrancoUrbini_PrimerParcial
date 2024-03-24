using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private Animator animator;

    public float speed = 5f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;

    private bool isGrounded;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset velocity when grounded
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Check if the player is moving
        bool isMoving = Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f;

        // Sprinting
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Adjust speed based on sprinting
        float currentSpeed = isSprinting ? speed * 2f : speed;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);

        // Check for jump input
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");

            // Check if the player is grounded and moving forward/backward
            if (isGrounded && Mathf.Abs(z) > 0.1f)
            {
                // Calculate jump velocity based on player's forward/backward movement
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
            // Check if the player is grounded and not moving (jump in place)
            else if (isGrounded && Mathf.Abs(z) <= 0.1f)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
            // Check if the player is grounded and moving sideways
            else if (isGrounded && Mathf.Abs(x) > 0.1f)
            {
                // Calculate jump velocity based on player's sideways movement
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                // Apply sideways velocity
                controller.Move(transform.right * x * currentSpeed * Time.deltaTime);
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply velocity to the controller
        controller.Move(velocity * Time.deltaTime);

        if (isMoving)
        {
            if (isSprinting)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
        }
        if (!isMoving)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
}
