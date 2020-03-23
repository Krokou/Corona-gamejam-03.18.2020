using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    Rigidbody2D rb;

    public bool bClimbing = false;
    public int iClimbSpeed = 10;
    public float fWallDirection;
    float fClimbDamper = 0.6f;
    float fSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        enabled = false;
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bClimbing)
        {
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isClimbing", true);
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isWalking", false);
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isJumping", false);
            rb.gravityScale = 0;

            // Climbing up and stop
            fWallDirection = 1;
            if (!GetComponentInChildren<PlayerFlip>().bFacingRight) fWallDirection = -1;

            /*
            float fVerticalVelocity = rb.velocity.y;
            fVerticalVelocity += Input.GetAxisRaw("Vertical") * fSpeed;
            fVerticalVelocity *= Mathf.Pow(1f - fClimbDamper, Time.deltaTime * 10f);
            */

            float fVerticalVelocity = rb.velocity.y;
            float fVerticalAxis = Input.GetAxisRaw("Vertical");
            if (fVerticalAxis < -0.01)
            {
                fVerticalVelocity += fVerticalAxis * fSpeed * GetComponent<PlayerStateMachine>().drunkValue;
            }
            float fHorizontalAxis = Input.GetAxisRaw("Horizontal");
            if (Mathf.Pow(fHorizontalAxis, 0) == Mathf.Pow(fWallDirection, 0))
            {
                fVerticalVelocity += Mathf.Abs(fHorizontalAxis) * fSpeed;
            }

            fVerticalVelocity *= Mathf.Pow(1f - fClimbDamper, Time.deltaTime * 10f);

            rb.velocity = new Vector2(rb.velocity.x, fVerticalVelocity);

            GetComponent<SpriteRenderer>().flipX = !GetComponentInChildren<PlayerFlip>().bFacingRight;
        }
        else
        {
            rb.gravityScale = 9;
            try
            {
                gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isClimbing", false);
            }
            catch { }
        }
        }
}
