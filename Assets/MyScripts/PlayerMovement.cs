using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    // ground
    public Transform groundCheck;
    public float groundCheckDistance;
    public LayerMask groundLayer;

    //speed
    public float forwardSpeed;
    public float sidewaysSpeed;
    public float jumpForce;

    //extra jumps
    public int extraJumps;
    private int jumpsLeft;

    //coyote time
    public float coyoteTime;
    private float coyoteTimeCounter;

    //jump buffer
    public float jumpBufferTime;
    private float jumpBufferCounter;
    void Update()
    {
        bool isStraight = Input.GetKey(KeyCode.UpArrow);
        bool isRight = Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isBack = Input.GetKey(KeyCode.DownArrow);
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        bool isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);

        //MOVEMENT
        if (isStraight)
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

        if (isRight)
        {
            transform.Translate(Vector3.right * sidewaysSpeed * Time.deltaTime);
        }

        if (isLeft)
        {
            transform.Translate(Vector3.left * sidewaysSpeed * Time.deltaTime);
        }

        if (isBack)
        {
            transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
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
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);

            if (!isGrounded)
            {
                jumpsLeft--;
            }
            jumpBufferCounter = 0;
        }
    }
}
