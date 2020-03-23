using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == "Wall" || collision.tag == "Ground") && GetComponentInParent<Climbing>().enabled)
        {
            GetComponentInParent<Climbing>().bClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Wall" || collision.tag == "Ground") && GetComponentInParent<Climbing>().enabled)
        {
            GetComponentInParent<Climbing>().bClimbing = false;
        }
    }
}
