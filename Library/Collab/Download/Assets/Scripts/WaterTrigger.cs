using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water" && GetComponentInParent<Swimming>().enabled)
        {
            GetComponentInParent<PlayerGroundMovement>().enabled = false;
            GetComponentInParent<Climbing>().enabled = false;

            GetComponentInParent<Rigidbody2D>().gravityScale = 0.3f;
            GetComponentInParent<Swimming>().bSwimming = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water" && GetComponentInParent<Swimming>().enabled)
        {
            GetComponentInParent<PlayerGroundMovement>().enabled = true;
            GetComponentInParent<Rigidbody2D>().gravityScale = 9f;
            if (GetComponentInParent<PlayerGroundMovement>().bCanClimb) GetComponentInParent<Climbing>().enabled = true;

            GetComponentInParent<Swimming>().SurfaceWater();
            GetComponentInParent<Swimming>().bSwimming = false;
        }
    }
}
