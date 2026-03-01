using UnityEngine;
using UnityEngine.InputSystem;

namespace MyGame
{


    public class AnimationStateContoller : MonoBehaviour
    {
        Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {
            bool isRunning = animator.GetBool("isRunning");
            bool isJumping = animator.GetBool("isJumping");

            bool isForward = Input.GetKey(KeyCode.UpArrow);
            bool isBackwards = Input.GetKey(KeyCode.DownArrow);
            bool isRight = Input.GetKey(KeyCode.RightArrow);
            bool isLeft = Input.GetKey(KeyCode.LeftArrow);
            bool isJump = Input.GetKeyDown(KeyCode.Space);
            bool isMelee = Input.GetKeyDown(KeyCode.X);

            //if player presses arrow up
            if ((isForward || isBackwards || isRight || isLeft) && !isRunning)
            {
                //player is running
                animator.SetBool("isRunning", true);
            }

            //if player is not pressing arrow up
            if (!(isForward || isBackwards || isRight || isLeft) && isRunning)
            {
                //player stops running
                animator.SetBool("isRunning", false);
            }

            //if player pressing space
            if (isJump && isRunning)
            {
                animator.SetBool("isJumping", true);
            }

            //if player stops pressing space
            if (!isJump && isJumping)
            {
                animator.SetBool("isJumping", false);
            }

            //if player is not moving and pressing space
            if (isJump && !isRunning)
            {
                animator.SetBool("isJumpInPlace", true);
            }

            //if player is not moving and not pressing space
            if (!isJump && !isRunning)
            {
                animator.SetBool("isJumpInPlace", false);
            }

            //if player presses x
            if (isMelee)
            {
                animator.SetBool("isPunch", true);
            }

            //if player is not pressing punch
            if (!isMelee)
            {
                animator.SetBool("isPunch", false);
            }



        }
    }

}