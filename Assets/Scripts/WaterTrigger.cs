using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water" && GetComponentInParent<Swimming>().enabled)
        {
            GetComponentInParent<Rigidbody2D>().gravityScale = 0.3f;
            GetComponentInParent<Swimming>().bSwimming = true;
            GetComponentInParent<PlayerGroundMovement>().bCanJump = false;
            GetComponentInParent<PlayerGroundMovement>().bCanWalk = false;
            if (GetComponentInParent<PlayerGroundMovement>().bCanClimb)
            {
                GetComponentInParent<Climbing>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water" && GetComponentInParent<Swimming>().enabled)
        {
            GetComponentInParent<Rigidbody2D>().gravityScale = 9f;
            GetComponentInParent<Swimming>().bSwimming = false;
            GetComponentInParent<Swimming>().SurfaceWater();
            if (GetComponentInParent<PlayerStateMachine>().state != 2) GetComponentInParent<PlayerGroundMovement>().bCanJump = true;
            GetComponentInParent<PlayerGroundMovement>().bCanWalk = true;
            if (GetComponentInParent<PlayerGroundMovement>().bCanClimb)
            {
                GetComponentInParent<Climbing>().enabled = true;
            }
        }
    }
}
