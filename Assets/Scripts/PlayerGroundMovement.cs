using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundMovement : MonoBehaviour
{
    public bool bGrounded;
    public bool bCanJump = true;
    public bool bCanFly = false;
    public bool bCanSwim = false;
    public bool bCanClimb = false;
    public bool bCanWalk = true;
    public bool bIsDrunk = false;
    int iWallJumpDirection;

    [SerializeField]
    float fJumpVelocity = 40;
    [SerializeField]
    float fSpeed = 1;
    Rigidbody2D rb;
    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;
    [SerializeField]
    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;
    [SerializeField]
    float fWallRemember = 0;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingBasic = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenStopping = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenTurning = 0.5f;

    [SerializeField]
    [Range(0, 1)]
    float fCutJumpHeight = 0.5f;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(int speed)
    {
        fSpeed = speed;
    }
    public void SetJumpVelocity(int velocity)
    {
        fJumpVelocity = velocity;
    }

    void Update()
    {
        try
        {
            if (bGrounded || GetComponent<Climbing>().bClimbing || GetComponent<Swimming>().bSwimming)
            {
                gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isJumping", false);
            }
            else
            {
                gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isJumping", true);
            }
        }
        catch { }
        if (bCanJump)
        {
            
            // Checks if we can jump
            fGroundedRemember -= Time.deltaTime;
            if (bGrounded)
            {
                try
                {
                    gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isFlying", false);
                }
                catch { }
                fGroundedRemember = fGroundedRememberTime;
            }
            // Checks if we want to jump
            fJumpPressedRemember -= Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                fJumpPressedRemember = fJumpPressedRememberTime;
            }

            // Checks if we want to stop jumping
            if (Input.GetButtonUp("Jump"))
            {
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * fCutJumpHeight);
                }
            }

            // Checks if we can walljump
            fWallRemember -= Time.deltaTime;
            if (GetComponent<Climbing>().bClimbing)
            {
                fWallRemember = fGroundedRememberTime;
                iWallJumpDirection = 1;
                try
                {
                    gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isWalking", false);
                }
                catch { }
                if (GetComponentInChildren<PlayerFlip>().bFacingRight) iWallJumpDirection = -1;
            } 

            // Actually jumps
            if ((fJumpPressedRemember > 0) && fWallRemember > 0)
            {
                fWallRemember = 0;
                fJumpPressedRemember = 0;
                fGroundedRemember = 0;

                rb.velocity = new Vector2(40 * iWallJumpDirection, fJumpVelocity);
            }
            else if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
            {
                fJumpPressedRemember = 0;
                fGroundedRemember = 0;
                rb.velocity = new Vector2(rb.velocity.x, fJumpVelocity);
            }
            if (rb.velocity.y < -25) rb.velocity = new Vector2(rb.velocity.x, -25);
        }
    }

    private void FixedUpdate()
    {
        if (bCanWalk)
        {
            if ((Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1))
            {
                gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isWalking", true);
            }
            else
            {
                gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isWalking", false);
            }
            float fHorizontalVelocity = rb.velocity.x;
            fHorizontalVelocity += Input.GetAxisRaw("Horizontal") * fSpeed * GetComponent<PlayerStateMachine>().drunkValue;

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)
                fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
        else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(fHorizontalVelocity))
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
        else
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);

            rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);
        }
    }
}