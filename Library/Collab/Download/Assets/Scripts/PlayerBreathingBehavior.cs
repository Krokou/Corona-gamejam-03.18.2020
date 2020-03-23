using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathingBehavior : MonoBehaviour
{
    public bool bCanBreathAir = true;
    public Countdown counter;

    private void OnEnable()
    {
        counter.ResetCounter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.tag == "Water")
            {
                if (bCanBreathAir)
                {
                    counter.ResetCounter();
                    counter.countDown.SetActive(true);
                    counter.enabled = true;
                }
                else
                {
                    counter.countDown.SetActive(false);
                    counter.enabled = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.tag == "Water")
            {
                if (bCanBreathAir)
                {
                    counter.countDown.SetActive(false);
                    counter.enabled = false;
                }
                else
                {
                    counter.ResetCounter();
                    counter.countDown.SetActive(true);
                    counter.enabled = true;
                }
            }
        }
    }
}
