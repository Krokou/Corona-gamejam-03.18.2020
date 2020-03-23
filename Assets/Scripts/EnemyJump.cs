using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpStrength = 30;
    public float jumpFrequency = 2;
    private float deltaTime = 0;

    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= jumpFrequency)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpStrength);
            deltaTime = 0;
        }
    }
}
