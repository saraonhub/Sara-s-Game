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
        // ground
        public Transform groundCheck;
        public float groundCheckDistance;
        public LayerMask groundLayer;

        //speed
        public float moveSpeed;
        public float jumpForce;

        private bool jumpRequest;
        //extra jumps
        public int extraJumps;
        private int jumpsLeft;

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
            bool isStraight = Input.GetKey(KeyCode.UpArrow);
            bool isRight = Input.GetKey(KeyCode.RightArrow);
            bool isLeft = Input.GetKey(KeyCode.LeftArrow);
            bool isBack = Input.GetKey(KeyCode.DownArrow);
            bool isJump = Input.GetKeyDown(KeyCode.Space);
            bool isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

            float moveX = 0f;
            float moveZ = 0f;

            //MOVEMENT
            if (isStraight)
            {
                moveZ = 1f;
            }
            if (isLeft)
            {
                moveX = -1f;
            }
            if (isRight)
            {
                moveX = 1f;
            }
            if (isBack)
            {
                moveZ = -1f;
            }

            moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

            //ROTATION
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 720 * Time.deltaTime);
            }

            //COYOTE TIME
            if (!isGrounded)
            {
                coyoteTimeCounter -= Time.deltaTime;
            }
            else
            {
                coyoteTimeCounter = coyoteTime;
            }

            //BUFFER TIME
            if (!isJump)
            {
                jumpBufferCounter -= Time.deltaTime;
            }
            else
            {
                jumpBufferCounter = jumpBufferTime;
            }

            //JUMP
            if (isGrounded)
            {
                jumpsLeft = extraJumps;
            }

            if ((coyoteTimeCounter > 0 || jumpsLeft > 0) && jumpBufferCounter > 0)
            {
                jumpRequest = true;


                if (!isGrounded && jumpsLeft > 0)
                {
                    jumpsLeft--;
                    doubleBark.Play();
                }
                jumpBufferCounter = 0;
            }
        }

        void FixedUpdate()
        {
            //MOVEMENT
            Vector3 horizontalVelocity = moveDirection * moveSpeed;

            rb.linearVelocity = new Vector3(
            horizontalVelocity.x,
            rb.linearVelocity.y,
            horizontalVelocity.z
        );

            //JUMP
            if (jumpRequest)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                jumpRequest = false;
            }

            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity += Vector3.up * Physics.gravity.y * (1.5f - 1) * Time.fixedDeltaTime;
            }
        }


    }



}