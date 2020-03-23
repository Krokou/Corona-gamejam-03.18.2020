using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float flyingSpeed = 2f;
    private Rigidbody2D rb;
    private PlayerGroundMovement groundMovement;

    public float damping = 0.6f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundMovement = GetComponent<PlayerGroundMovement>();
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = rb.velocity.x + Input.GetAxisRaw("Horizontal") * flyingSpeed;
        float verticalVelocity = rb.velocity.y + Input.GetAxisRaw("Vertical") * flyingSpeed;
        try
        {
            gameObject.GetComponent<PlayerStateMachine>().animator.SetBool("isFlying", true);
        }
        catch { }

        horizontalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10f);
        verticalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10f);

        rb.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
