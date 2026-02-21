using NUnit.Framework;
using UnityEngine;

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

            if (!isGrounded)
            {
                jumpsLeft--;
            }
            jumpBufferCounter = 0;
        }
    }

    void FixedUpdate()
    {
        //MOVEMENT
        Vector3 movement = moveDirection * moveSpeed;
        Vector3 newPosition = rb.position + movement * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        //JUMP
        if (jumpRequest)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpRequest = false;
        }

    }
}
