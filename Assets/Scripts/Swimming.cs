using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    //public PlayerGroundMovement controller;
    public float swimSpeed = 0.58f;
    public float swimSpeedUp = 0.25f;
    private Rigidbody2D rb;
    private PlayerGroundMovement groundMovement;
    public bool bSwimming = false;

    private float damping = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (bSwimming)
        {
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isSwimming", true);
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isWalking", false);
            float horizontalVelocity = rb.velocity.x + Input.GetAxisRaw("Horizontal") * swimSpeed * GetComponent<PlayerStateMachine>().drunkValue;
            float verticalVelocity = rb.velocity.y + Input.GetAxisRaw("Vertical") * (swimSpeedUp + 0.5f) * GetComponent<PlayerStateMachine>().drunkValue;

            horizontalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10f);
            verticalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10f);

            rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
        }  else if (!bSwimming)
        {
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isSwimming", false);
        }
    }

    public void SurfaceWater()
    {
        rb.velocity = new Vector2(rb.velocity.x, 20f);
        try
        {
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isjumping", true);
        }
        catch { }
    }
}
