using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
namespace MyGame
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        private Vector3 moveDirection;
        // GROUND
        public Transform groundCheck;
        public float groundCheckDistance;
        public LayerMask groundLayer;
        //speed
        public float moveSpeed;
        public float jumpForce;
        private bool jumpRequest;
        //extra jumps
        public int extraJumps = 1;
        private int jumpsLeft;

        private bool isGrounded;
        //coyote time
        public float coyoteTime;
        private float coyoteTimeCounter;
        //jump buffer
        public float jumpBufferTime;
        private float jumpBufferCounter;
        //smooth turning
        public float turnSmoothTime = 0.1f;
        //bark
        public AudioSource doubleBark;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            HandleInput();
            CheckGrounded();
            HandleCoyoteTime();
            HandleJumpBuffer();
            HandleJumpRequest();
        }
        void FixedUpdate()
        {
            HandleMovement();
            HandleJumpPhysics();
            HandleFallMultiplier();
        }
        private void HandleInput()
        {
            float moveX = 0f;
            float moveZ = 0f;

            if (Input.GetKey(KeyCode.UpArrow)) moveZ = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) moveZ = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;
            if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;

            moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

            // Jump input with buffering
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBufferCounter = jumpBufferTime;
            }
        }

        private void CheckGrounded()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        }

        private void HandleCoyoteTime()
        {
            if (isGrounded)
            {
                coyoteTimeCounter = coyoteTime;
                jumpsLeft = extraJumps;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime;
            }
        }

        private void HandleJumpBuffer()
        {
            if (jumpBufferCounter > 0)
                jumpBufferCounter -= Time.deltaTime;
        }

        private void HandleJumpRequest()
        {
            if (jumpBufferCounter <= 0) return; //to make sure nothing happens if we are not pressing input

            bool isDoubleJump = coyoteTimeCounter <= 0 && jumpsLeft > 0;

            if (coyoteTimeCounter > 0) //first jump
            {
                jumpRequest = true;
                jumpBufferCounter = 0;
                return;
            }

            if (jumpsLeft == 1) //double jump
            {
                jumpRequest = true;
                jumpsLeft--;

                if (isDoubleJump)
                {
                    doubleBark.Play();
                }

                jumpBufferCounter = 0;
            }
        }
        private void HandleMovement()
        {
            if (moveDirection != Vector3.zero)
            {
                // Smooth rotation
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.fixedDeltaTime);
            }

            Vector3 horizontalVelocity = moveDirection * moveSpeed;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }

        private void HandleJumpPhysics()
        {
            if (jumpRequest)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                jumpRequest = false;
            }
        }

        private void HandleFallMultiplier()
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity += Vector3.up * Physics.gravity.y * (2.5f - 1) * Time.fixedDeltaTime;
            }
        }
    }
}

