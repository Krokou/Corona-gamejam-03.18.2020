using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWalk : MonoBehaviour
{
    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft = .5f;       // Define wallLeft
    public float wallRight =.5f;
    // Define wallRight

    public float walkDistance = 1;
    float walkingDirection = 1.0f;

    Vector2 walkAmount;
    float originalX; // Original float value


    void Start()
    {
       
        wallLeft = transform.position.x - .5f;
        wallRight = transform.position.x + .5f;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight)
        {
            walkingDirection = -1;
        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDirection = 1;
        }
        transform.Translate(walkAmount);
    }
        }
    
