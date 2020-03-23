using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    float fDirection = 0;
    public bool bFacingRight = true;
    Rigidbody2D rb;
    float fHorizontalAxis;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        fDirection = rb.velocity.x;
        if (fDirection > 0.01)
        {
            bFacingRight = true;
        }
        else if (fDirection < -0.01)
        {
            bFacingRight = false;
        }
        fHorizontalAxis = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(fHorizontalAxis) > 0.01f)
        {
            if (fHorizontalAxis < 0) GetComponent<SpriteRenderer>().flipX = true;
            else GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}