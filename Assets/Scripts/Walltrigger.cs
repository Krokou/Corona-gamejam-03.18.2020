using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walltrigger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && GetComponentInParent<Climbing>().enabled)
        {
            GetComponentInParent<Climbing>().bClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && GetComponentInParent<Climbing>().enabled)
        {
            GetComponentInParent<Climbing>().bClimbing = false;
        }
    }
}
