using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensitivity : MonoBehaviour
{
    public Countdown counter;

    private void OnEnable()
    {
        counter.enabled = true;
        counter.countDown.SetActive(true);
        counter.ResetCounter();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.tag == "Darkness")
            {
                counter.countDown.SetActive(false);
                counter.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.tag == "Darkness")
            {
                counter.ResetCounter();
                counter.countDown.SetActive(true);
                counter.enabled = true;
            }
        }
    }
}
